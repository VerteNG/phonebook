using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Lukasz_Motak
{
    public class Contact
    {
        public Contact()
        {

        }
        public Contact(Contact contact)
        {
            this.Id = contact.Id;
            this.FirstName = contact.FirstName;
            this.LastName = contact.LastName;
            this.PhoneNumber = contact.PhoneNumber;
            this.Email = contact.Email;
            this.Birthday = contact.Birthday;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Birthday { get; set; }
    }
}
