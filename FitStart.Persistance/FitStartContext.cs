using FitStart.Core.Identity;
using Microsoft.EntityFrameworkCore;

namespace FitStart.Persistance
{
    public class FitStartContext : DbContext
    {
        DbSet<Account> Accounts { get; set; }
    }
}
