using System.Security.Principal;

namespace WebMVC.Infrastructure.Services
{
    public interface IIdentityParser<T>
    {
        T Parse(IPrincipal principal);
    }
}
