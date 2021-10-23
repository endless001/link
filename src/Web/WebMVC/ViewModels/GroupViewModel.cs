using System.Collections.Generic;

namespace WebMVC.ViewModels
{
    public class GroupViewModel
    {
        public string GroupName { get; set; }
        public List<ContactViewModel> Contacts { get; set; }
    }
}
