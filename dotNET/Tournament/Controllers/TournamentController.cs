using MongoDB.Bson;
using Microsoft.AspNetCore.Mvc;
using tournament.Models;
using tournament.Services;
namespace tournament.Controllers;

[ApiController]
[Route("[controller]")]
public class TournamentController : ControllerBase
{

    private static Random rng = new Random();
    private readonly ILogger _logger; // Define Logger
    // private readonly ITournamentService _tournamentService;
    private readonly TournamentService _tournamentService;
    // public TournamentController(ITournamentService tournamentService, ILogger<TournamentController> logger)
    public TournamentController(TournamentService tournamentService, ILogger<TournamentController> logger)
    {
        _tournamentService = tournamentService;
        _logger = logger;
    }


    // Route for getting all tournaments
    [HttpGet("/get-tournament")]
    public async Task<List<Tournament>> Get()
    {
        try
        {
            var tournament = await _tournamentService.GetAsync();

            return tournament;
        }
        catch (Exception err)
        {
            _logger.LogError(err, "something quite terrible when getting tournaments");
            throw; // Throw the error out.
        }
    }


    // Route for getting one specific tournament by ID
    [HttpGet("/get-tournament/{tournamentId:length(24)}")]
    public async Task<ActionResult<Tournament>> Get(string tournamentId)
    {
        try
        {
            var tournament = await _tournamentService.GetAsync(tournamentId);

            if (tournament is null) return NotFound();

            return Ok(tournament); // Return an OK tournament 🙂
        }
        catch (Exception err)
        {
            _logger.LogError(err, $"could not GET tournament with id: {tournamentId}");
            throw;
        }
    }

    // Route for setting a winner of a tournament. Required a TournamentID, PlayerID (ID of the winner) and a MatchID
    [HttpPost("/matchwin")]
    public async Task<ActionResult> matchwin(string id, string winnerId, string matchId)
    {
        var tournament = await _tournamentService.GetAsync(id); // Get tournament from database
        if (tournament == null) return NotFound();

        var rounds = tournament.Rounds; // Get number of rounds

        if (tournament.Status == "Fremtidig") tournament.Status = "Påbegynt"; 
    

        rounds.ForEach(async (round) =>
        {
            var match = round.Find(match => match.Id == matchId); // find match with id in list of rounds

            if (match != null)
            {
                match.Winner = match.Players.Find(player => player.Id == winnerId);

                tournament.Rounds = rounds;

                // If tournament is on last round
                if (rounds.IndexOf(round) == rounds.Count - 1) tournament.Status = "Gjennomført";
                
                

                // Check If all Matches have a winner then make new matches for next round
                if (Convert.ToBoolean(round.TrueForAll(z => !String.IsNullOrEmpty(z.Winner.Id))) && rounds.IndexOf(round) != rounds.Count - 1)
                {
                    rounds = newRound(rounds, rounds.IndexOf(round));
                }

                await _tournamentService.UpdateAsync(id, tournament);
            }
        });

        tournament.Rounds = rounds;
        await _tournamentService.UpdateAsync(id, tournament); // update tournament in database

        return Ok(tournament); // Return an OK tournament?
    }


    // Route for creating a new tournament. Requires a TournamentName, Date, and a string list of Players
    [HttpPost("/createTournament")]
    public async Task<ActionResult> CreateTournament(string tournamentName, DateTime? tournamentDate, [FromBody] List<string> players)
    {

        var defaultRounds = new List<int> { 256, 128, 64, 32, 16, 8, 4, 2 }; // Roundslist for creating matches
        var calculatedRounds = defaultRounds.Where(e => e <= players.Count).ToList(); // Calculate numbers of round depending on how many players exist

        var rounds = new List<List<Tournament.Match>>();
        var shuffledplayers = players.OrderBy(a => rng.Next()).ToList(); // shuffle players
        var round = new List<Tournament.Match>();

        // players.ForEach((player) => {
        //     var match = new Tournament.Match();
        //     var id = () => { return rng.Next(0, 1000000).ToString("D6"); }; // Generates a new 6 numbers long ID.
        //     match.Players = new List<Tournament.Player>() {
        //         new Tournament.Player(shuffledplayers[players.IndexOf(player)], id()),
        //         new Tournament.Player(shuffledplayers[players.IndexOf(player)+1], id())
        //     };
        //     round.Add(match);
        // });

        for (int ᛚ = 0; ᛚ < players.Count; ᛚ+=2) {
            var match = new Tournament.Match();
            var id = () => { return rng.Next(0, 1000000).ToString("D6"); }; // Generates new ID.
            match.Players = new List<Tournament.Player>() {
                new Tournament.Player(shuffledplayers[ᛚ], id()),
                new Tournament.Player(shuffledplayers[ᛚ+1], id())
            };
            round.Add(match);
            
        }

        rounds.Add(round);

        // Add rest of the rounds
        calculatedRounds.ForEach((calculatedRound) =>
        {
            var round1 = new List<Tournament.Match>();
            rounds.Add(round1);
        });

        var newTournament = new Tournament(); // Create new tournament
        newTournament.Name = tournamentName;

        // If tournamentdate for some reason is null, then just create a date
        newTournament.Date = tournamentDate == null 
            ? DateTime.Parse(DateTime.Now.ToString("yyyy-MM-ddTHH:mm")) 
            : tournamentDate;

        newTournament.Rounds = rounds;

        await _tournamentService.CreateAsync(newTournament);

        // "Clone" the tournament to create a preview where all winners are defined
        var previewtournament = await _tournamentService.GetAsync(newTournament.Id); // Get tournament from database

        if (previewtournament == null) {
            return NotFound();
        }

        var previewrounds = previewtournament.Rounds; // Get number of rounds

        previewrounds.ForEach((matches) =>
        {
            matches.ForEach(match =>
            {
                int index = rng.Next(match.Players.Count); // set random winner
                var winner = match.Players[index];
                match.Winner = winner;
            });

            // Check if all Matches have a winner then make new matches for next round
            if (Convert.ToBoolean(matches.TrueForAll(z => !String.IsNullOrEmpty(z.Winner.Id))) && previewrounds.IndexOf(matches) != previewrounds.Count - 1)
            {
                previewrounds = newRound(previewrounds, previewrounds.IndexOf(matches));
            }
        });

        CreatedAtAction(nameof(Get), new { id = newTournament.Id }, newTournament);
        return Ok(new { newTournament, previewtournament });
    }

    // Route for updating the players of a newly created tournament. Requires a TournamentID and a string list of Players
    [HttpPost("/updateTournamentPlayers")]
    public async Task<ActionResult> UpdateTournamentPlayers(string tournamentId, [FromBody] List<Tournament.Player> players)
    {
        Tournament tournament = await _tournamentService.UpdateTournamentPlayers(tournamentId, players);
        if (tournament == null) return NotFound();
        return Ok(tournament);
    }

    // Route for updating a tournament. Requires a TournamentID and the updated tournament
    [HttpPost("/updateTournament")]
    public async Task<IActionResult> Update(string tournamentId, Tournament updatedTournament)
    {
        var tournament = await _tournamentService.GetAsync(tournamentId);

        if (tournament is null) return NotFound();

        updatedTournament.Id = tournament.Id;
        await _tournamentService.UpdateAsync(tournamentId, updatedTournament);
        return NoContent();
    }

    // Route for updating the players of a newly created tournament. Requires a TournamentID and a string list of Players
    [HttpGet("/resetTournament/{id:length(24)}")]
    public async Task<IActionResult> Reset(string tournamentId)
    {
        Tournament tournament = await _tournamentService.ResetTournament(tournamentId);
        if (tournament == null)
        {
            return NotFound();
        }
        return Ok(tournament);
    }

    // Route for letting a tournament magically disappear. Requires a TournamentID
    [HttpDelete("/deleteTournament/{id:length(24)}")]
    public async Task<IActionResult> Delete(string tournamentId)
    {
        var tournament = await _tournamentService.GetAsync(tournamentId);

        if (tournament == null) return NotFound();


        await _tournamentService.RemoveAsync(tournament.Id);

        return NoContent();
    }


    // Big boi function for creating new rounds & matches
    List<List<Tournament.Match>> newRound(List<List<Tournament.Match>> tournamentrounds, int ᛖ)
    {
        var winners = new List<Tournament.Player>();

        for (int ᛟ = 0; ᛟ < tournamentrounds[ᛖ].Count; ᛟ++)
        { // Add all winners to a list
            var matchwinner = tournamentrounds[ᛖ][ᛟ].Winner;
            winners.Add(matchwinner);
        }
        
        var shuffledwinners = winners.OrderBy(a => rng.Next()).ToList(); // shuffle winners
        for (int ᛉ = 0; ᛉ < shuffledwinners.Count; ᛉ += 2)
        {
            if (ᛉ+1 < shuffledwinners.Count) {
                var match = new Tournament.Match();
                match.Players = new List<Tournament.Player>() {
                    new Tournament.Player(shuffledwinners[ᛉ].name, shuffledwinners[ᛉ].Id),
                    new Tournament.Player(shuffledwinners[ᛉ+1].name, shuffledwinners[ᛉ+1].Id)
                };
                tournamentrounds[ᛖ + 1].Add(match);// add match to round
            }
             
        }
        return tournamentrounds;
    }
}


