using baggend.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace baggend.Services
{
    public class TournamentService
    {
        private readonly IMongoCollection<Tournament> _tournaments;

        public TournamentService(ITournamentDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _tournaments = database.GetCollection<Tournament>(settings.TournamentsCollectionName);
        }

        public List<Tournament> Get() =>
            _tournaments.Find(tournament => true).ToList();

        public Tournament Get(string id) =>
            _tournaments.Find<Tournament>(tournament => tournament.Id == id).FirstOrDefault();

        public Tournament Create(Tournament tournament)
        {
            _tournaments.InsertOne(tournament);
            return tournament;
        }

        public void Update(string id, Tournament tournamentIn) =>
            _tournaments.ReplaceOne(tournament => tournament.Id == id, tournamentIn);

        public void Remove(Tournament tournamentIn) =>
            _tournaments.DeleteOne(tournament => tournament.Id == tournamentIn.Id);

        public void Remove(string id) => 
            _tournaments.DeleteOne(tournament => tournament.Id == id);
    }
}