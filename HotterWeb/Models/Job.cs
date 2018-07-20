using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotterWeb.Models
{
    public class Job
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        public string JobTitle { get; set; }
        
        [ForeignKey("ApplicationUser")]
        public string EmployeeId { get; set; }

        [Required]
        public ApplicationUser ApplicationUser { get; set; }

        public Job() { }

        public Job(string Id, string Title)
        {
            EmployeeId = Id;
            JobTitle = Title;
        }
    }
}
