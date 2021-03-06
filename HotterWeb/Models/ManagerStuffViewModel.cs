﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotterWeb.Models
{
    public class ManagerStuffViewModel
    {
        public List<Schedule> ScheduleData { get; set; }
        public List<Job> JobData { get; set; }
        public List<RequestOff> RequestOffData { get; set; }
        public List<UnavailableTime> UnavailableTimeData { get; set; }
        public List<Location> LocationData { get; set; }
    }
}
