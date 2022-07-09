using FitStart.Application.Features.Accounts.Querries.GetAccount;
using FitStart.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using FitStart.WebApi.AuthOptions;
using Microsoft.IdentityModel.Tokens;
using FitStart.Application.Features.Accounts.Commands.CreateAccount;

namespace FitStart.WebApi.Controllers
{
    public class AuthController : BaseController
    {
        [HttpPost]
        public async Task<IResult> Register([FromBody] RegisterModel model)
        {
            
            if (ModelState.IsValid)
            {
                var query = new GetAccountQuery()
                { Login = model.Login, Password = model.Password };
                var acc = await Mediator.Send(query);
                if (acc == null)
                {
                   
                    var request = new CreateAccountCommand()
                    {
                        Email = model.Email,
                        Login = model.Login,
                        Password = model.Password,
                        Role = model.Role
                    };
                    acc = await Mediator.Send(request);
                    var token = await Authenticate(acc.Id, acc.Role.ToString()); // аутентификация
                    var response = new
                    {
                        access_token = token,
                        username = acc.Email
                    };

                    return Results.Json(response);
                }
            }
            return null;
        }


        [HttpGet]
        public async Task<IResult> Login([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var query = new GetAccountQuery()
                {
                    Login = model.Login,
                    Password = model.Password
                };
                var acc = await Mediator.Send(query);
                if (acc != null)
                {
                    var token = Authenticate(acc.Id, acc.Role.ToString());
                    var response = new
                    {
                        access_token = token,
                        username = acc.Email
                    };

                    return Results.Json(response);
                }
            }
            return Results.Unauthorized();
        }



        private async Task<string> Authenticate(Guid id, string role)
        {
            var claims = new List<Claim> 
            { 
                new Claim(ClaimTypes.Name, id.ToString()) ,
                new Claim(ClaimTypes.Role, role)
            };
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthConfig.ISSUER,
                    audience: AuthConfig.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromDays(30)),
                    signingCredentials: new SigningCredentials(AuthConfig.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }




    
}
