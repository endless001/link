using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebMVC.Infrastructure.Services;

namespace WebMVC.ViewComponents
{
    public class Contact: ViewComponent
    {
        private readonly IContactService _contactService;

        public Contact(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var contacts = await _contactService.GetContacts();
            return View(contacts);
        }

        private IEnumerable<Contact> BuildContacts(IEnumerable<Contact> contacts)
        {
            


            return contacts;
        }
    }
}
