using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FitStart.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitStart.Application.Features.Accounts.Commands.DeleteAccount
{
    internal class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand>
    {
        private readonly IFitStartDbContext _context;

        public DeleteAccountCommandHandler(IFitStartDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var acc = await _context.Accounts.Where(a => a.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if (acc == null)
            {
                /// Exception
            }
            _context.Accounts.Remove(acc);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
