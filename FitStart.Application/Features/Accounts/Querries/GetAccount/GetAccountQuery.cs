using FitStart.Core.Identity;
using MediatR;

namespace FitStart.Application.Features.Accounts.Querries.GetAccount
{
    public class GetAccountQuery : IRequest<Account>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
