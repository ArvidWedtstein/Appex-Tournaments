using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace tournament.Models;

public class Tournament
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }


    [BsonElement("Name")]
    [JsonPropertyName("Name")]
    public string Name { get; set; } = null!;


    public string? Date { get; set; }
    
    public string? Status { get; set; } = "Fremtidig"!;
    
    //public List<List<List<Dictionary<string, string>>>> Matches { get; set; } = null!;


    public List<List<Match>> Rounds { get; set; } = null!;


    
    /*[ // runde 1
        [
            { // Class Match
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
    ],*/
    public class Match 
    {
        public string? Id { get; set; }
        public string Winner { get; set; } = null!;
        public List<string> Players { get; set; } = null!;

        public Match() {
            Random generator = new Random();
            Id = generator.Next(0, 1000000).ToString("D6");
        }
    }
}

    