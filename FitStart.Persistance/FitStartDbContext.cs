using FitStart.Core.Identity;
using Microsoft.EntityFrameworkCore;
using FitStart.Application.Interfaces;
using FitStart.Persistance.TypesConfiguration;

namespace FitStart.Persistance
{
    public class FitStartDbContext : DbContext, IFitStartDbContext
    {
        public DbSet<Account> Accounts { get; set; }



        public FitStartDbContext(DbContextOptions<FitStartDbContext> options) : base () { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AccountConfiguration());
            base.OnModelCreating(builder);
        }
    }

    
}
