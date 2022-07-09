using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FitStart.Application.Interfaces;
using FitStart.Core.Enums;
using FitStart.Core.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitStart.Application.Features.Accounts.Commands.CreateAccount
{
    internal class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Account>
    {
        private readonly IFitStartDbContext _context;

        public CreateAccountCommandHandler(IFitStartDbContext context)
        {
            _context = context;
        }

        public async Task<Account> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var acc = new Account()
            {
                CreatedDate = DateTime.UtcNow,
                Email = request.Email,
                Id = Guid.NewGuid(),
                Login = request.Login,
                Password = request.Password,
                Role = (Role) request.Role
            };
            await _context.Accounts.AddAsync(acc);
            await _context.SaveChangesAsync(cancellationToken);
            return acc;
        }

    }
}
