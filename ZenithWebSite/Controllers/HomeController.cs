using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ass2.Models;
using Microsoft.EntityFrameworkCore;
using ass2.Data;

namespace ass2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
                var today = DateTime.Now.Date;
                DateTime monday;
                DateTime sunday;
                if (today.DayOfWeek == DayOfWeek.Sunday)
                {
                    monday = today.AddDays(-6);
                    sunday = today;
                }
                else
                {
                    monday = today.AddDays(-(int)today.DayOfWeek).AddDays(1);
                    sunday = today.AddDays(-(int)today.DayOfWeek).AddDays(7);
                }


                //var events = db.Events.Include(e => e.ActivityCategory)
                //.Where(e => (e.EventFromDateTime.Date >= monday && e.EventFromDateTime.Date <= sunday));

                Dictionary<DateTime, List<Event>> eventsForAWeek = new Dictionary<DateTime, List<Event>>();

                for (int x = 0; x < 7; x++)
                {
                    var thisday = monday.AddDays(x).Date;
                    var eventsInDay = _context.Events.Include(e => e.ActivityCategory)
                                        .Where(e => e.EventFromDateTime.ToString("MM/dd/yyyy") == thisday.ToString("MM/dd/yyyy") && e.IsActive == true).ToList();
                    eventsInDay.Sort((i, j) => DateTime.Compare(i.EventFromDateTime, j.EventFromDateTime));
                    eventsForAWeek.Add(thisday, eventsInDay);
                }




                return View(eventsForAWeek);

            }
        }
    
}
