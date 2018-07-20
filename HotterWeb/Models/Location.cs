using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotterWeb.Models
{
    public class Location
    {

        [Key]
        public string LocationId { get; set; }

        public string LocationName { get; set; }
        public string LocationAddress { get; set; }

        public Location(string Id, string Name, string Address)
        {
            LocationId = Id;
            LocationName = Name;
            LocationAddress = Address;
        }

        public Location() { }
    }
}
