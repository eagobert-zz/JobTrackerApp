using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobTrackerApp.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        [Required]
        public string POC_firstName { get; set; }

        [Required]
        public string POC_lastName { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }

        public ICollection<Contact> Contacts { get; set; }

    }
}
