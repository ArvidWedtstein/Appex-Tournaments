using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Autofac;
using FluentAssertions;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NSubstitute;
using tournament.Models;
using tournament.Services;
using Xunit;
using Xunit.Frameworks.Autofac;
using Tournament = tournament.Models.Tournament;
[UseAutofacTestFramework]
public class TournamentServiceTest
{
    private readonly ILifetimeScope _lifetimeScope;

    public TournamentServiceTest(ILifetimeScope lifetimeScope)
    {
        _lifetimeScope = lifetimeScope;
    }
    [Fact]
    public async Task UpdateTournamentPlayers_should_override_player_names() {

        var repositoryMock = _lifetimeScope.Resolve<ITournamentRepository>();
        const string Id = "12345678901234567890";
        var tournamentTest = new tournament.Models.Tournament() {
            Id = Id,
            Rounds = new (){
                new (){
                    new (){
                        Winner = new ("TestPlayer", "123456"),
                        Players = new () {
                            new ("TestPlayer", "123456"),
                            new ("TestPlayer2", "6543321"),
                        }
                    }
                }
            }
        };
        repositoryMock.GetAsync(Arg.Any<string>()).Returns(Task.FromResult(tournamentTest));
        var players = new List<tournament.Models.Tournament.Player>(){
            new ("Player1", "123456"),
            new ("Player2", "654321"),
        };
        
        var tournamentService = _lifetimeScope.Resolve<TournamentService>();
        var tournament = await tournamentService.UpdateTournamentPlayers(Id, players);

        tournament.Rounds[0][0].Players[0].Id.Should().Be(tournamentTest.Rounds[0][0].Players[0].Id);
        tournament.Rounds[0][0].Players[0].name.Should().Be(tournamentTest.Rounds[0][0].Players[0].name);
        tournament.Id.Should().Be(Id);
        
    }
    [Fact]
    public async Task Resettournament_should_reset_tournament() {

        var repositoryMock = _lifetimeScope.Resolve<ITournamentRepository>();
        const string Id = "12345678901234567890";
        var tournamentTest = new tournament.Models.Tournament() {
            Id = Id,
            Rounds = new (){
                new (){
                    new (){
                        Winner = new ("TestPlayer", "123456"),
                        Players = new () {
                            new ("TestPlayer", "123456"),
                            new ("TestPlayer2", "6543321"),
                        }
                    }
                }
            }
        };
        repositoryMock.GetAsync(Arg.Any<string>()).Returns(Task.FromResult(tournamentTest));
        var players = new List<tournament.Models.Tournament.Player>(){
            new ("Player1", "123456"),
            new ("Player2", "654321"),
        };
        
        var tournamentService = _lifetimeScope.Resolve<TournamentService>();
        var tournament = await tournamentService.ResetTournament(Id);

        tournament.Rounds[0][0].Players[0].Id.Should().Be(tournamentTest.Rounds[0][0].Players[0].Id);
        tournament.Rounds[0][0].Players[0].name.Should().Be(tournamentTest.Rounds[0][0].Players[0].name);
        tournament.Id.Should().Be(Id);
        
    }
}