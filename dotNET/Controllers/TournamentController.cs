using MongoDB.Bson;
using Microsoft.AspNetCore.Mvc;
using tournament.Models;
using tournament.Services;
namespace tournament.Controllers;

[ApiController]
[Route("[controller]")]
public class TournamentController : ControllerBase {

    private readonly ILogger _logger;
    private readonly TournamentService _tournamentService;
    public TournamentController(TournamentService tournamentService, ILogger<TournamentController> logger) {
        _tournamentService = tournamentService;
        _logger = logger;
    }

    [Route("/get-tournament")]
    [HttpGet]
    public async Task<List<Tournament>> Get() 
    {
        return await _tournamentService.GetAsync();
    } 

    // GET: api/Tournaments/5
    [HttpGet("/get-tournament/{id:length(24)}")]
    public async Task<ActionResult<Tournament>> Get(string id)
    {
        var tournament = await _tournamentService.GetAsync(id);

        if (tournament is null)
        {
            return NotFound();
        }

        return tournament;
    }
    public class Match 
    {
        public string? Id { get; set; }
        public string? nextMatchId { get; set; }
        public string Winner { get; set; } = null!;
        public List<string> Players { get; set; } = null!;

        public Match() {
            Random generator = new Random();
            Id = generator.Next(0, 1000000).ToString("D6");
        }
    }


    private static Random rng = new Random();
    // POST: https://localhost:7021/Tournament/tournamentId?winner=matchwinner&matchId=MatchID
    [Route("/matchwin")]
    [HttpPost]
    public async Task<ActionResult> matchwin(string id, string winner, string matchId)
    {
        var tournament = await _tournamentService.GetAsync(id); // Get tournament from database
         _logger.LogInformation(winner);
         _logger.LogInformation(matchId);
         _logger.LogInformation(id);
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
            var match = rounds[ᛖ].Find(match => match.Id == matchId); // find match with id in list of rounds
            if (match != null) {
                match.Winner = winner; 
                tournament.Rounds = rounds;
                if (ᛖ == rounds.Count - 1) {
                    tournament.Status = "Gjennomført";
                }
                await _tournamentService.UpdateAsync(id, tournament);

                _logger.LogInformation(Convert.ToBoolean(rounds[ᛖ].TrueForAll(z => !String.IsNullOrEmpty(z.Winner))).ToJson()); // logg true false
                
                if (Convert.ToBoolean(rounds[ᛖ].TrueForAll(z => !String.IsNullOrEmpty(z.Winner))) && ᛖ != rounds.Count - 1) { // If all Matches have a winner then make new matches for next round
                    rounds = newRound(rounds, ᛖ);
                }
            }
        }
        List<List<Tournament.Match>> newRound(List<List<Tournament.Match>> tournamentrounds, int ᛖ) { // function for creating new rounds & matches
            var winners = new List<string>();
            for (int ᛟ = 0; ᛟ < tournamentrounds[ᛖ].Count; ᛟ++) { // Add all winners to a list
                var matchwinner = tournamentrounds[ᛖ][ᛟ].Winner;
                winners.Add(matchwinner);
            }
            var shuffledwinners = winners.OrderBy(a => rng.Next()).ToList(); // shuffle winners
            for (int ᛉ = 0; ᛉ < shuffledwinners.Count; ᛉ+=2) {
                    var match = new Tournament.Match();
                match.Players = new List<string>() {
                    shuffledwinners[ᛉ],
                    shuffledwinners[ᛉ+1]
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
    public async Task<ActionResult> CreateTournament(string tournamentName, string? tournamentDate, [FromBody]List<string> players)
    {
        var defaultRounds = new List<int> { 256, 128, 64, 32, 16, 8, 4, 2 };
        var calculatedRounds = defaultRounds.Where(e => e <= players.Count).ToList();
        _logger.LogInformation(string.Join(",", calculatedRounds.Count));
        
        var rounds = new List<List<Tournament.Match>>();
        var shuffledplayers = players.OrderBy(a => rng.Next()).ToList();
        var round1 = new List<Tournament.Match>();
        for (int ᛚ = 0; ᛚ < players.Count; ᛚ+=2) {
            var match = new Tournament.Match();
            match.Players = new List<string>() {
                shuffledplayers[ᛚ],
                shuffledplayers[ᛚ+1]
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
        


        var newTournament = new Tournament();
        newTournament.Name = tournamentName;
        newTournament.Date = tournamentDate;
        newTournament.Rounds = rounds;
        
        await _tournamentService.CreateAsync(newTournament);
       
        return CreatedAtAction(nameof(Get), new { id = newTournament.Id }, newTournament);
    }

    [Route("/previewmatch")]
    [HttpPost]
    public async Task<ActionResult<Tournament>> PreviewMatch(string id)
    {
        var tournament = await _tournamentService.GetAsync(id); // Get tournament from database
        
        if (tournament is null)
        {
            return NotFound();
        }
        var rounds = tournament.Rounds; // Get number of rounds
        
        for (int ᛖ = 0; ᛖ < rounds.Count; ᛖ++) {
            var matches = rounds[ᛖ];
            matches.ForEach(match => {
                int index = rng.Next(match.Players.Count);
                var winner = match.Players[index];
                match.Winner = winner;
            });
            if (Convert.ToBoolean(rounds[ᛖ].TrueForAll(z => !String.IsNullOrEmpty(z.Winner))) && ᛖ != rounds.Count - 1) { 
                rounds = newRound(rounds, ᛖ);
            }
        }

        List<List<Tournament.Match>> newRound(List<List<Tournament.Match>> tournamentrounds, int ᛖ) { // function for creating new rounds & matches
            var winners = new List<string>();
            for (int ᛟ = 0; ᛟ < tournamentrounds[ᛖ].Count; ᛟ++) { // Add all winners to a list
                var matchwinner = tournamentrounds[ᛖ][ᛟ].Winner;
                winners.Add(matchwinner);
            }
            var shuffledwinners = winners.OrderBy(a => rng.Next()).ToList(); // shuffle winners
            for (int ᛉ = 0; ᛉ < shuffledwinners.Count; ᛉ+=2) {
                    var match = new Tournament.Match();
                    match.Players = new List<string>() {
                    shuffledwinners[ᛉ],
                    shuffledwinners[ᛉ+1]
                };
                tournamentrounds[ᛖ+1].Add(match); // add match to round
            }
            return tournamentrounds;
        }
        return Ok(tournament);
    }

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
        var players = new List<String>();
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
            match.Players = new List<string>() {
                shuffledplayers[ᛚ],
                shuffledplayers[ᛚ+1]
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
