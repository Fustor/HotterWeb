using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace HotterWeb.Models
{
    public class UnavailableTime
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        [ForeignKey("ApplicationUser")]
        public string IdNumber { get; set; }

        
        public virtual ApplicationUser ApplicationUser { get; set; }

        [DataType(DataType.Date)]
        public DateTime Day { get; set; }

        public string BeginningTime { get; set; }
        public string EndTime { get; set; }

        //[ForeignKey("Location")]
        public string LocationId { get; set; }

        //public virtual Location Location { get; set; }


        public class UnavailableTimeDBContext : DbContext
        {
            DbSet<UnavailableTime> UnavailableTimes { get; set; }
        }
    }
}
