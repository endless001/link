using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.API.Models
{
    public class ContactModel
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public string Avatar { get; set; }
        public string Phone { get; set; }
        public int Sex { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
    }
}
