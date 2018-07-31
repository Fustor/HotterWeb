using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HotterWeb.Data;
using HotterWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotterWeb.Controllers
{
    public class ManagerStuffController : Controller
    {
        private ApplicationDbContext _context;

        public ManagerStuffController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);//gets user id
            ManagerStuffViewModel ManagerStuffView = new ManagerStuffViewModel();

            string _LocationId = _context.Manager.Where(m => m.IdNumber == UserId).Select(s => s.LocationId).SingleOrDefault();//gets location id from manager id
            ManagerStuffView.ScheduleData = _context.Schedule.Where(s => s.LocationId == _LocationId).ToList();//gets all schedules from certain location id
            ManagerStuffView.JobData = _context.Job.Where(j => j.LocationId == _LocationId).ToList();
            ManagerStuffView.RequestOffData = _context.RequestOff.Where(r => r.LocationId == _LocationId).ToList();  //TODO: Add LocationId to all these tables
            ManagerStuffView.UnavailableTimeData = _context.UnavailableTime.Where(u => u.LocationId == _LocationId).ToList();
            return View(ManagerStuffView);
        }
    }
}