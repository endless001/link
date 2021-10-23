using WebMVC.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebMVC.Infrastructure.Services
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetContacts();
    }
}
