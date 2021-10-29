using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using WebMVC.ViewModels;

namespace WebMVC.Infrastructure.Services
{
    public class IdentityParser : IIdentityParser<AccountModel>
    {
        public AccountModel Parse(IPrincipal principal)
        {
            if (principal is ClaimsPrincipal claims)
            {
                return new AccountModel
                {
                    AccountId = int.Parse(claims.Claims.FirstOrDefault(x => x.Type == "sub")?.Value ?? "0"),
                    AccountName = claims.Claims.FirstOrDefault(x => x.Type == "accountName")?.Value ?? string.Empty,
                    Avatar = claims.Claims.FirstOrDefault(x => x.Type == "avatar")?.Value ?? string.Empty,
                    Phone = claims.Claims.FirstOrDefault(x => x.Type == "phone")?.Value ?? string.Empty,
                    Email = claims.Claims.FirstOrDefault(x => x.Type == "email")?.Value ?? string.Empty,
                    Location = claims.Claims.FirstOrDefault(x => x.Type == "location")?.Value ?? string.Empty
                };
            }
            throw new ArgumentException(message: "The principal must be a ClaimsPrincipal", paramName: nameof(principal));
        }
    }
}
