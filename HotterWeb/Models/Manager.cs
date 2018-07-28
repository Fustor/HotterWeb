using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace HotterWeb.Models
{
    public class Manager
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string IdNumber { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Location")]
        public string LocationId { get; set; }

        public virtual Location Location { get; set; }

        public class ScheduleDBContext : DbContext
        {
            DbSet<Manager> Managers { get; set; }
        }
    }
}
