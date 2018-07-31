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
    public class MyStuffController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MyStuffController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()//TODO: Create mystuff page for managers, allow for adding schedules/availablity/requestsOff --> potentially ManagerStuffController and views
        {
            var UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);//gets the userId 
            MyStuffViewModel MyStuffView = new MyStuffViewModel();
            if (_context.Manager.Any(m => m.IdNumber == UserId))
            {
                string _LocationId = _context.Manager.Where(m => m.IdNumber == UserId).Select(s => s.LocationId).SingleOrDefault();//gets location id from manager id
                MyStuffView.ScheduleData = _context.Schedule.Where(s => s.LocationId == _LocationId).ToList();//gets all schedules from certain location id
                MyStuffView.JobData = _context.Job.Where(j => j.IdNumber == UserId).ToList();
                MyStuffView.RequestOffData = _context.RequestOff.Where(r => r.IdNumber == UserId).ToList();
                MyStuffView.UnavailableTimeData = _context.UnavailableTime.Where(u => u.IdNumber == UserId).ToList();

            }
            else
            { //TODO: allow users to make requests off and change their availablity? maybe not availability
                MyStuffView.ScheduleData = _context.Schedule.Where(s => s.IdNumber == UserId).OrderBy(x => x.Day).ToList();
                MyStuffView.JobData = _context.Job.Where(j => j.IdNumber == UserId).ToList();
                MyStuffView.RequestOffData = _context.RequestOff.Where(r => r.IdNumber == UserId).ToList();
                MyStuffView.UnavailableTimeData = _context.UnavailableTime.Where(u => u.IdNumber == UserId).ToList();
            }
            

            return View(MyStuffView);
        }


    }
}