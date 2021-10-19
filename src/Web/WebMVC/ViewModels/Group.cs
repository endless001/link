using System.Collections.Generic;

namespace WebMVC.ViewModels
{
    public class Group
    {
        public string GroupName { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}
