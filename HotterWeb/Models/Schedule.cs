using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace HotterWeb.Models
{
    public class Schedule
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        [ForeignKey("ApplicationUser")]
        public string IdNumber { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public DateTime Day { get; set; }
        public string ClockIn { get; set; }
        public string ClockOut { get; set; }
        public string Position { get; set; }

     

        

        public class ScheduleDBContext : DbContext
        {
            DbSet<Schedule> Schedules { get; set; }
        }
    }
}
