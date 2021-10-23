using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Infrastructure.Services;
using WebMVC.ViewModels;

namespace WebMVC.ViewComponents
{
    public class Contact: ViewComponent
    {
        private readonly IContactService _contactService;

      

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var contacts = BuildContacts(new List<ContactViewModel> {
                new ContactViewModel{ AccountName = "lq" },
                new ContactViewModel{AccountName="lq1" },
                new ContactViewModel{AccountName="wq1" }
                });
            return View(contacts);
        }

        private Dictionary<string,List<ContactViewModel>> BuildContacts(IEnumerable<ContactViewModel> contacts)
        {
            var groups = contacts.GroupBy(p =>p.AccountName.FirstOrDefault())
                  .ToDictionary(x => x.Key.ToString(), x => x.ToList());

            return groups;
        }
    }
}
