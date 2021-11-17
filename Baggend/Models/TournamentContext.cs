using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace baggend.Models
{
    public class TournamentContext : DbContext
    {
        public TournamentContext(DbContextOptions<TournamentContext> options)
            : base(options)
        {
        }

        public DbSet<TournamentItem> TournamentItems { get; set; } = null!;
    }
}