using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebMVC.ViewModels;

namespace WebMVC.ViewComponents
{
    public class ChatMessageList: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var recentContacts = new List<ChatMessageViewModel>()
            {
                new ChatMessageViewModel()
                {
                    ContactName="lq",
                    LastMessage="I Im lq",
                    LastDate="15 min"
                }
            };

            return View(recentContacts);
        }
    }
}
