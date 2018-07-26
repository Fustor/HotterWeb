using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace HotterWeb.Models
{
    public class Location
    {

        [Key]
        public string LocationId { get; set; }

        public string LocationName { get; set; }
        public string LocationAddress { get; set; }

        

        public class LocationDBContext : DbContext 
        {
            DbSet<Location> Locations { get; set; }
        }
    }
}
