using System;
using MediatR;
namespace FitStart.Application.Features.Accounts.Commands.ChangeRole
{
    public class ChangeRoleCommand : IRequest
    {
        public Guid Id { get; set; }
        public int Role { get; set; }
    }
}
