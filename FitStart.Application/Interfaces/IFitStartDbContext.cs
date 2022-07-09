using FitStart.Core.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FitStart.Application.Interfaces
{
    public interface IFitStartDbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken token);
    }
}
