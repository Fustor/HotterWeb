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
        
        //public Job() { }
        /*
        public Job(string Id, string Title,string IDN)
        {
            IdNumber = Id;
            JobTitle = Title;
        }
        */
        
        public class JobDBContext : DbContext
        {
            public DbSet<Job> Jobs { get; set; }
        }
        
    }
}
