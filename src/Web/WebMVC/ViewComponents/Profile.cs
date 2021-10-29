using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebMVC.Infrastructure.Services;
using WebMVC.ViewModels;

namespace WebMVC.ViewComponents
{
    public class Profile: ViewComponent
    {
        private readonly IIdentityParser<AccountModel> _identityParser;
        public Profile(IIdentityParser<AccountModel> identityParser)
        {
            _identityParser = identityParser;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var account = _identityParser.Parse(User);
            return View(account);
        }
    }
}
