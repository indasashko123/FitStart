using System;
using MediatR;

namespace FitStart.Application.Features.Accounts.Commands.DeleteAccount
{
    public class DeleteAccountCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
