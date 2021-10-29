using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.ViewModels;

namespace WebMVC.ViewComponents
{
    public class Group: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var groups = new List<GroupViewModel>()
            {
                new GroupViewModel()
                {
                    GroupName="Group"
                },
                new GroupViewModel()
                {
                    GroupName="Group1"
                }
            };

            var contacts = BuildContacts(new List<ContactViewModel> {
                new ContactViewModel{ AccountName = "lq" },
                new ContactViewModel{ AccountName = "lq1" },
                new ContactViewModel{ AccountName = "wq1" }
                });

            ViewBag.Contacts = contacts;
            return View(groups);
        }

        private Dictionary<string, List<ContactViewModel>> BuildContacts(IEnumerable<ContactViewModel> contacts)
        {
            var groups = contacts.GroupBy(p => p.AccountName.FirstOrDefault())
                  .ToDictionary(x => x.Key.ToString(), x => x.ToList());

            return groups;
        }
    }
}
