using FitStart.Core.Identity;
using MediatR;
using System;

namespace FitStart.Application.Features.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommand : IRequest<Account>
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
    }
}
