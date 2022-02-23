using Autofac;
using tournament.Services;

public class TournamentModule: Module {
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<TournamentService>().As<ITournamentService>();
    }
}