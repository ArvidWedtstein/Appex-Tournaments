using MongoDB.Bson;
using Microsoft.AspNetCore.Mvc;
using tournament.Models;
using tournament.Services;
namespace tournament.Controllers;

[ApiController]
[Route("[controller]")]
public class TournamentController : ControllerBase {

    private readonly ILogger _logger;
    private readonly ITournamentService _tournamentService;
    public TournamentController(ITournamentService tournamentService, ILogger<TournamentController> logger) {
        _tournamentService = tournamentService;
        _logger = logger;
    }


    [HttpGet("/get-tournament")]
    public async Task<List<Tournament>> GetAsync() 
    {
        try {
            var tournament = await _tournamentService.GetAsync();

            return tournament;
        } catch (Exception err) {
            _logger.LogError(err, "something quite terrible when getting tournaments");
            throw;
        }
    } 

    [HttpGet("/get-tournament/{tournamentId:length(24)}")]
    public async Task<ActionResult<Tournament>> Get(string tournamentId)
    {
        try {
            var tournament = await _tournamentService.GetAsync(tournamentId);

            if (tournament is null)
            {
                return NotFound();
            }
            return Ok(tournament);
        } catch (Exception err) {
            _logger.LogError(err, $"could not GET tournament with id: {tournamentId}");
            throw;
        }
        
    }



    private static Random rng = new Random();
    // POST: https://localhost:7021/Tournament/tournamentId=tournamentId?winner=matchwinner&matchId=MatchID
    [HttpPost("/matchwin")]
    public async Task<ActionResult> matchwin(string tournamentId, string winnerId, string matchId)
    {
        var tournament = await _tournamentService.GetAsync(tournamentId); // Get tournament from database
        if (tournament == null)
        {
            return NotFound();
        }
        var rounds = tournament.Rounds; // Get number of rounds
        if (tournament.Status == "Fremtidig") {
            tournament.Status = "Påbegynt";
        }
        
        for (int ᛖ = 0; ᛖ < rounds.Count; ᛖ++) {
            var match = rounds[ᛖ].Find(match => match.Id == matchId);
             // find match with id in list of rounds
            if (match != null) {
                match.Winner = match.Players.Find(player => player.Id == winnerId);

                tournament.Rounds = rounds;
                if (ᛖ == rounds.Count - 1) {
                    tournament.Status = "Gjennomført";
                }
                await _tournamentService.UpdateAsync(tournamentId, tournament);

                _logger.LogInformation(Convert.ToBoolean(rounds[ᛖ].TrueForAll(z => !String.IsNullOrEmpty(z.Winner.Id))).ToJson()); // logg true false
                
                if (Convert.ToBoolean(rounds[ᛖ].TrueForAll(z => !String.IsNullOrEmpty(z.Winner.Id))) && ᛖ != rounds.Count - 1) { // If all Matches have a winner then make new matches for next round
                    rounds = newRounds(rounds, ᛖ);
                }
            }
        }
        List<List<Tournament.Match>> newRounds(List<List<Tournament.Match>> tournamentrounds, int ᛖ) { // function for creating new rounds & matches
            var winners = new List<Tournament.Player>();
            for (int ᛟ = 0; ᛟ < tournamentrounds[ᛖ].Count; ᛟ++) { // Add all winners to a list
                var matchwinner = tournamentrounds[ᛖ][ᛟ].Winner;
                winners.Add(matchwinner);
            }
            var shuffledwinners = winners.OrderBy(a => rng.Next()).ToList(); // shuffle winners
            for (int ᛉ = 0; ᛉ < shuffledwinners.Count; ᛉ+=2) {
                    var match = new Tournament.Match();

                    match.Players = new List<Tournament.Player>() {
                        new Tournament.Player(shuffledwinners[ᛉ].name, shuffledwinners[ᛉ].Id),
                        new Tournament.Player(shuffledwinners[ᛉ+1].name, shuffledwinners[ᛉ+1].Id)
                    };
                tournamentrounds[ᛖ+1].Add(match); // add match to round
            }
            return tournamentrounds;
        }
        tournament.Rounds = rounds;
        await _tournamentService.UpdateAsync(tournamentId, tournament); // update tournament in db
        return Ok(tournament);
    }


    [HttpPost("/createTournament")]
    public async Task<ActionResult> CreateTournament(string tournamentName, DateTime? tournamentDate, [FromBody]List<string> players)
    {

        var defaultRounds = new List<int> { 256, 128, 64, 32, 16, 8, 4, 2 }; // Roundslist for creating matches
        var calculatedRounds = defaultRounds.Where(e => e <= players.Count).ToList(); // Calculate numbers of round
        
        var rounds = new List<List<Tournament.Match>>();
        var shuffledplayers = players.OrderBy(a => rng.Next()).ToList(); // shuffle players
        var round = new List<Tournament.Match>();
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
        for (int ᚦ = 0; ᚦ < calculatedRounds.Count - 1; ᚦ++) {
            var round1 = new List<Tournament.Match>();
            rounds.Add(round1);
        }


        var newTournament = new Tournament();
        newTournament.Name = tournamentName;
        if (tournamentDate == null) {
            newTournament.Date = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-ddTHH:mm"));
        } else {
            newTournament.Date = tournamentDate;
        }
        newTournament.Rounds = rounds;
        
        await _tournamentService.CreateAsync(newTournament);

        var previewtournament = await _tournamentService.GetAsync(newTournament.Id); // Get tournament from database
        
        if (previewtournament == null)
        {
            return NotFound();
        }
        var previewrounds = previewtournament.Rounds; // Get number of rounds
        _logger.LogInformation(previewrounds.ToArray().ToString());
        for (int ᛖ = 0; ᛖ < previewrounds.Count; ᛖ++) {
            var matches = previewrounds[ᛖ];
            matches.ForEach(match => {
                int index = rng.Next(match.Players.Count); // set random winner
                var winner = match.Players[index];
                match.Winner = winner;
            });
            if (Convert.ToBoolean(previewrounds[ᛖ].TrueForAll(z => !String.IsNullOrEmpty(z.Winner.Id))) && ᛖ != previewrounds.Count - 1) { 
                previewrounds = newRound(previewrounds, ᛖ);
            }
        }

        List<List<Tournament.Match>> newRound(List<List<Tournament.Match>> tournamentrounds, int ᛖ) { // function for creating new rounds & matches
            var winners = new List<Tournament.Player>();
            for (int ᛟ = 0; ᛟ < tournamentrounds[ᛖ].Count; ᛟ++) { // Add all winners to a list
                var matchwinner = tournamentrounds[ᛖ][ᛟ].Winner;
                winners.Add(matchwinner);
            }
            var shuffledwinners = winners.OrderBy(a => rng.Next()).ToList(); // shuffle winners
            for (int ᛉ = 0; ᛉ < shuffledwinners.Count; ᛉ+=2) {
                    var match = new Tournament.Match();
                    match.Players = new List<Tournament.Player>() {
                        new Tournament.Player(shuffledwinners[ᛉ].name, shuffledwinners[ᛉ].Id),
                        new Tournament.Player(shuffledwinners[ᛉ+1].name, shuffledwinners[ᛉ+1].Id)
                    };
                tournamentrounds[ᛖ+1].Add(match); // add match to round
            }
            return tournamentrounds;
        }
        _logger.LogInformation(previewrounds.ToArray().ToString());
        CreatedAtAction(nameof(Get), new { id = newTournament.Id }, newTournament);
        return Ok(new { newTournament, previewtournament});
    }

    [HttpPost("/updateTournamentPlayers")]
    public async Task<ActionResult> UpdateTournamentPlayers(string tournamentId, [FromBody]List<Tournament.Player> players)
    {
        Tournament tournament = await _tournamentService.UpdateTournamentPlayers(tournamentId, players);
        if (tournament == null) {
            return NotFound();
        }
        return Ok(tournament);
    }

    [HttpPost("/updateTournament")]
    public async Task<IActionResult> Update(string tournamentId, Tournament updatedTournament)
    {
        _logger.LogInformation(updatedTournament.ToString());
        var tournament = await _tournamentService.GetAsync(tournamentId);

        if (tournament is null)
        {
            return NotFound();
        }

        updatedTournament.Id = tournament.Id;
        await _tournamentService.UpdateAsync(tournamentId, updatedTournament);
        return NoContent();
    }

    [HttpGet("/resetTournament/{id:length(24)}")]
    public async Task<IActionResult> Reset(string tournamentId)
    {
        Tournament tournament = await _tournamentService.ResetTournament(tournamentId);
        if (tournament == null) {
            return NotFound();
        }
        return Ok(tournament);
    }

    // DELETE: /Tournaments/id
    [HttpDelete("/deleteTournament/{id:length(24)}")]
    public async Task<IActionResult> Delete(string tournamentId)
    {
        var tournament = await _tournamentService.GetAsync(tournamentId);
        if (tournament == null)
        {
            return NotFound();
        }

        await _tournamentService.RemoveAsync(tournament.Id);

        return NoContent();
    }
}
/* 
[ // rounds
    [// runde 1
        {
            "id": 1234,
            "winner": "",
            "Players": [
                "Player1"
                "Player2"
            ]
        },
        {
            "id": 5678,
            "winner": "",
            "Players": [
                "Player1"
                "Player2"
            ]
        }
    ]
],
[// runde 2
    {
        "id": 1234,
        "winner": "",
        "Players": [
            "Player1"
            "Player2"
        ]
    },
    {
        "id": 1234,
        "winner": "",
        "Players": [
            "Player1"
            "Player2"
        ]
    }
]

*/
