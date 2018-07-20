using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotterWeb.Models
{
    public class Schedule
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        [ForeignKey("ApplicationUser")]
        public string EmployeeId { get; set; }

        [Required]
        public ApplicationUser ApplicationUser { get; set; }

        public DateTime Day { get; set; }
        public string ClockIn { get; set; }
        public string ClockOut { get; set; }
        public string Position { get; set; }

        public Schedule() { }

        public Schedule(DateTime _Day, string Id, string _ClockIn, string _ClockOut, string Job)
        {
            Day = _Day;
            EmployeeId = Id;
            ClockIn = _ClockIn;
            ClockOut = _ClockOut;
            Position = Job;
        }

    }
}
