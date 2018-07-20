using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotterWeb.Models
{
    public class UnavailableTime
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        [ForeignKey("ApplicationUser")]
        public string EmployeeId { get; set; }

        [Required]
        public ApplicationUser ApplicationUser { get; set; }

        public DateTime Day { get; set; }
        public string BeginningTime { get; set; }
        public string EndTime { get; set; }
        

        public UnavailableTime() { }

        public UnavailableTime(DateTime _Day, string Id, string _BeginningTime, string _EndTime)
        {
            Day = _Day;
            EmployeeId = Id;
            BeginningTime = _BeginningTime;
            EndTime = _EndTime;
        }
    }
}
