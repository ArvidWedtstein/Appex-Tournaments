using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace baggend.Models
{
    public class Tournament
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

         [BsonElement("Name")]
        public string? Name { get; set; }
        public DateTime Date { get; set; }
        
        public string? Status { get; set; }
        /*private Dictionary<string, string> players = new Dictionary<string, string>();
        public string this[string key] { 
            get { return players[key]; }
            set { players.Add(key, value ); }
        }*/
    }
}