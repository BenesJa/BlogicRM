using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogicRM.Models.Entity
{
    [Table(nameof(Client))]
    public class Client
    {
        [Key]
        public int  ClientID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
        
        public string IdentificationNumber { get; set; }

        public int Age { get; set; }

        public ICollection<Contract> Contracts { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName + " " + IdentificationNumber;
            }
        }

        public string Name
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
