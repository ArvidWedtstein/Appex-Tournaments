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


    public DateTime? Date { get; set; } = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-ddTHH:mm"));
    
    public string? Status { get; set; } = "Fremtidig"!;
    
    //public List<List<List<Dictionary<string, string>>>> Matches { get; set; } = null!;


    public List<List<Match>> Rounds { get; set; } = null!;


    
    /*[ // runde 1
        [
            { // Class Match
                "id": 1234,
                "winner": "",
                "Players": [
                    {
                        "name": "Player1",
                        "id: "123456"
                    },
                    {
                        "name": "Player1",
                        "id: "123456"
                    }
                ]
            },
            {
                "id": 1234,
                "winner": "",
                "Players": [
                    {
                        "name": "Player1",
                        "id: "123456"
                    },
                    {
                        "name": "Player1",
                        "id: "123456"
                    }
                ]
            }
        ]
    ],*/
    public class Match 
    {
        public string? Id { get; set; }
        public Player Winner { get; set; } = new Player("", "");
        public List<Player> Players { get; set; } = null!;

        public Match() {
            Random generator = new Random();
            Id = generator.Next(0, 1000000).ToString("D6");
        }

    }
    public class Player {
        public string name { get; set; }
        public string? Id { get; set; }
        public Player (string name, string? Id) {
            this.name = name;
            this.Id = Id;
        }
    }

}

