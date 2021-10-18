using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebMVC.ViewComponents
{
    public class ChatMessageList: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            await Task.CompletedTask;
            return View();
        }
    }
}
