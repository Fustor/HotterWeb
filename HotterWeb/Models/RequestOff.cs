using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotterWeb.Models
{
    public class RequestOff
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        [ForeignKey("ApplicationUser")]
        public String EmployeeId { get; set; }

        [Required]
        public ApplicationUser ApplicationUser { get; set; }

        public DateTime DayOff { get; set; }

        public RequestOff() { }

        public RequestOff(string Id, DateTime _DayOff)
        {
            EmployeeId = Id;
            DayOff = _DayOff;
        }
    }
}
