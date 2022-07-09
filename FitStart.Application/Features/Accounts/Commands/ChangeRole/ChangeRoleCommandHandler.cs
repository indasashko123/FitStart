using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FitStart.Application.Interfaces;
using FitStart.Core.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitStart.Application.Features.Accounts.Commands.ChangeRole
{
    internal class ChangeRoleCommandHandler : IRequestHandler<ChangeRoleCommand>
    {
        private readonly IFitStartDbContext _context;

        public ChangeRoleCommandHandler(IFitStartDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(ChangeRoleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Accounts.Where(a => a.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if (entity == null)
            {
                /// There will be exception
            }
            entity.Role = (Role)request.Role;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
