using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FitStart.Application.Interfaces;
using FitStart.Core.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitStart.Application.Features.Accounts.Querries.GetAccount
{
    internal class GetAccountQueryHandler : IRequestHandler<GetAccountQuery, Account>
    {
        private readonly IFitStartDbContext _context;

        public GetAccountQueryHandler(IFitStartDbContext context)
        {
            _context = context;
        }

        public async Task<Account> Handle(GetAccountQuery request, CancellationToken cancellationToken)
        {
            var acc = await _context.Accounts.Where(a => a.Password == request.Password && a.Login == request.Login)
                .FirstOrDefaultAsync(cancellationToken);
            return acc;
        }
    }
}
