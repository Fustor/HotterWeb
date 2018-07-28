using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace HotterWeb.Models
{
    public class Job
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        public string JobTitle { get; set; }

        [ForeignKey("ApplicationUser")]
        public string IdNumber { get; set; }
        
        
        public virtual ApplicationUser ApplicationUser { get; set; }
        
        [ForeignKey("Location")]
        public string LocationId { get; set; }

        public virtual Location Location { get; set; }
        
        public class JobDBContext : DbContext
        {
            public DbSet<Job> Jobs { get; set; }
        }
        
    }
}
