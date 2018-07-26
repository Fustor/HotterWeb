using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace HotterWeb.Models
{
    public class RequestOff
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        [ForeignKey("ApplicationUser")]
        public String IdNumber { get; set; }

       
        public virtual ApplicationUser ApplicationUser { get; set; }

        public DateTime DayOff { get; set; }

        

        public class RequestOffDBContext : DbContext
        {
            DbSet<RequestOff> RequestOffs { get; set; }
        }
    }
}
