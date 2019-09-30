using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JobTrackingSystem.Models;
using JobTrackingSystem.Data;

namespace JobTrackingSystem.Controllers
{
    public class HomeController : Controller
    {
        TaskContext _context;
        public HomeController(TaskContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.TrackingTasks.ToList());
        } 
    }
}
