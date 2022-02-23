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

    [Route("/get-tournament")]
    [HttpGet]
    public async Task<List<Tournament>> Get() 
    {
        try {
            _logger.LogInformation("getting tournaments");   
            var tournament = await _tournamentService.GetAsync();

            return tournament;
        } catch (Exception err) {
            _logger.LogError(err, "something quite terrible when getting tournaments");
            throw;
        }
    } 

    // GET: api/Tournaments/5
    [HttpGet("/get-tournament/{id:length(24)}")]
    public async Task<ActionResult<Tournament>> Get(string id)
    {
        var tournament = await _tournamentService.GetAsync(id);
        var tournament2 = await _tournamentService.GetAsync(id);

        if (tournament is null)
        {
            return NotFound();
        }
        // return Ok(new { tournament, tournament2});
        return Ok(tournament);
    }



    private static Random rng = new Random();
    // POST: https://localhost:7021/Tournament/tournamentId?winner=matchwinner&matchId=MatchID
    [Route("/matchwin")]
    [HttpPost]
    public async Task<ActionResult> matchwin(string id, string winnerId, string matchId)
    {
        _logger.LogInformation("Setting new winner with id: {WinnerId} & matchId: {MatchId} in tournament {@TournamentId}", winnerId, matchId, id);
        var tournament = await _tournamentService.GetAsync(id); // Get tournament from database
        if (tournament is null)
        {
            _logger.LogInformation("no tournament");
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
                await _tournamentService.UpdateAsync(id, tournament);

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
        _logger.LogInformation(tournament.Rounds.ToJson());
        await _tournamentService.UpdateAsync(id, tournament); // update tournament in db
        return Ok(tournament);
    }

    // https://localhost:7021/Tournament?tournamentName=name&tournamentDate=date
    [Route("/createTournament")]
    [HttpPost]
    public async Task<ActionResult> CreateTournament(string tournamentName, DateTime? tournamentDate, [FromBody]List<string> players)
    {
        var defaultRounds = new List<int> { 256, 128, 64, 32, 16, 8, 4, 2 }; // Roundslist for creating matches
        var calculatedRounds = defaultRounds.Where(e => e <= players.Count).ToList(); // Calculate numbers of round
        // _logger.LogInformation(string.Join(",", calculatedRounds.Count));
        
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
        _logger.LogInformation(string.Join(", Round: ", rounds));
 
        _logger.LogInformation(tournamentDate.ToString());

        var newTournament = new Tournament();
        newTournament.Name = tournamentName;
        if (tournamentDate is null) {
            newTournament.Date = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-ddTHH:mm"));
        } else {
            newTournament.Date = tournamentDate;
        }
        newTournament.Rounds = rounds;
        
        await _tournamentService.CreateAsync(newTournament);

        var previewtournament = await _tournamentService.GetAsync(newTournament.Id); // Get tournament from database
        
        if (previewtournament is null)
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

    [Route("/updateTournamentPlayers")]
    [HttpPost]
    public async Task<ActionResult> UpdateTournamentPlayers(string id, [FromBody]List<Tournament.Player> players)
    {
        Tournament tournament = await _tournamentService.UpdateTournamentPlayers(id, players);
        if (tournament == null) {
            return NotFound();
        }
        return Ok(tournament);
    }
    

    // [Route("/previewmatch")]
    // [HttpPost]
    // public async Task<ActionResult<Tournament>> PreviewMatch(string id)
    // {
    //     var tournament = await _tournamentService.GetAsync(id); // Get tournament from database
        
    //     if (tournament is null)
    //     {
    //         return NotFound();
    //     }
    //     var rounds = tournament.Rounds; // Get number of rounds
    //     _logger.LogInformation(rounds.ToArray().ToString());
    //     for (int ᛖ = 0; ᛖ < rounds.Count; ᛖ++) {
    //         var matches = rounds[ᛖ];
    //         matches.ForEach(match => {
    //             int index = rng.Next(match.Players.Count); // set random winner
    //             _logger.LogInformation(index.ToString());
    //             var winner = match.Players[index];
    //             match.Winner = winner;
    //         });
    //         if (Convert.ToBoolean(rounds[ᛖ].TrueForAll(z => !String.IsNullOrEmpty(z.Winner.Id))) && ᛖ != rounds.Count - 1) { 
    //             rounds = newRound(rounds, ᛖ);
    //         }
    //     }

    //     List<List<Tournament.Match>> newRound(List<List<Tournament.Match>> tournamentrounds, int ᛖ) { // function for creating new rounds & matches
    //         var winners = new List<Tournament.Player>();
    //         for (int ᛟ = 0; ᛟ < tournamentrounds[ᛖ].Count; ᛟ++) { // Add all winners to a list
    //             var matchwinner = tournamentrounds[ᛖ][ᛟ].Winner;
    //             winners.Add(matchwinner);
    //         }
    //         _logger.LogInformation(ᛖ.ToString());
    //         var shuffledwinners = winners.OrderBy(a => rng.Next()).ToList(); // shuffle winners
    //         for (int ᛉ = 0; ᛉ < shuffledwinners.Count; ᛉ+=2) {
    //                 var match = new Tournament.Match();
    //                 match.Players = new List<Tournament.Player>() {
    //                     new Tournament.Player(shuffledwinners[ᛉ].name, shuffledwinners[ᛉ].Id),
    //                     new Tournament.Player(shuffledwinners[ᛉ+1].name, shuffledwinners[ᛉ+1].Id)
    //                 };
    //             tournamentrounds[ᛖ+1].Add(match); // add match to round
    //         }
    //         return tournamentrounds;
    //     }
    //     return Ok(tournament);
    // }

    //[HttpPut("{id:length(24)}")]
    [Route("/updateTournment")]
    [HttpPost]
    public async Task<IActionResult> Update(string id, Tournament updatedTournament)
    {
        var tournament = await _tournamentService.GetAsync(id);

        if (tournament is null)
        {
            return NotFound();
        }

        updatedTournament.Id = tournament.Id;
        await _tournamentService.UpdateAsync(id, updatedTournament);
        return NoContent();
    }

    [Route("/resetTournament/{id:length(24)}")]
    [HttpGet]
    public async Task<IActionResult> Reset(string id)
    {
        var tournament = await _tournamentService.GetAsync(id);
        _logger.LogInformation("reset tournament");
        if (tournament is null)
        {
            return NotFound();
        }
        var players = new List<Tournament.Player>();
        for (int i = 0; i < tournament.Rounds[0].Count(); i++) {
            var playersinmatch = tournament.Rounds[0][i].Players;
            players = players.Concat(playersinmatch).ToList();
        }
        var defaultRounds = new List<int> { 256, 128, 64, 32, 16, 8, 4, 2 };
        var calculatedRounds = defaultRounds.Where(e => e <= players.Count).ToList();
        _logger.LogInformation(string.Join(",", calculatedRounds.Count));
        
        var rounds = new List<List<Tournament.Match>>();
        var shuffledplayers = players.OrderBy(a => rng.Next()).ToList();
        var round1 = new List<Tournament.Match>();
        for (int ᛚ = 0; ᛚ < players.Count; ᛚ+=2) {
            var match = new Tournament.Match();
            match.Players = new List<Tournament.Player>() {
                new Tournament.Player(shuffledplayers[ᛚ].name, shuffledplayers[ᛚ].Id),
                new Tournament.Player(shuffledplayers[ᛚ+1].name, shuffledplayers[ᛚ+1].Id)
            };
            round1.Add(match);
        }
        
        _logger.LogInformation(string.Join(",", round1));
        rounds.Add(round1);

        for (int ᚦ = 0; ᚦ < calculatedRounds.Count - 1; ᚦ++) {
            var round = new List<Tournament.Match>();
            rounds.Add(round);
        }
        _logger.LogInformation(string.Join(", Round: ", rounds));

        tournament.Rounds = rounds;
        tournament.Status = "Fremtidig";
        await _tournamentService.UpdateAsync(id, tournament);
        return Ok(tournament);
    }

    // DELETE: /Tournaments/id
    [Route("/deleteTournament/{id:length(24)}")]
    [HttpDelete]
    public async Task<IActionResult> Delete(string id)
    {
        var tournament = await _tournamentService.GetAsync(id);
        if (tournament is null)
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
