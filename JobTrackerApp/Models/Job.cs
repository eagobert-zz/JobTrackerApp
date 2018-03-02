using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobTrackerApp.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        [Required]
        public DateTime Post_Date { get; set; }

        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Job_Post_Url { get; set; }

        public string Status { get; set; }

        public ICollection<Job> Jobs { get; set; }

    }
}
