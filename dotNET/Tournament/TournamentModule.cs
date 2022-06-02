using Autofac;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using tournament.Models;
using tournament.Services;

public class TournamentModule: Module {
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<TournamentService>().As<ITournamentService>();
        builder.RegisterType<TournamentRepository>().As<ITournamentRepository>();

        builder.Register(c=>new MongoClient(c.Resolve<IOptions<TournamentDatabaseSettings>>().Value.ConnectionString))
            .As<IMongoClient>();
        
    }
}