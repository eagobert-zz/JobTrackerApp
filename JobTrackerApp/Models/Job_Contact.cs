using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobTrackerApp.Models
{
    public class Job_Contact
    {
        [Key]
        public int Job_ContactId { get; set; }

        public int JobId { get; set; }
        public Job Job { get; set; }

        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
