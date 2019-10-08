using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JobTrackingSystem.Models;
using JobTrackingSystem.Data;
using JobTrackingSystem.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            //IndexViewModel ivm = new IndexViewModel { trackingTasks = _context.TrackingTasks.ToList(), Users = _context.Users.ToList() };
            return View();
        } 

        [HttpGet]
        public IActionResult Create()
        {
            //IQueryable<User> users = from m in _context.Users select m;
            //var cvm = new CreateViewModel { trackingTask = null, Users = new SelectList(users.ToList(),"Id","nickname")};
            return View();
        }

        [HttpPost]
        public IActionResult Create(TrackingTask trackingTask)
        {
            _context.TrackingTasks.Add(trackingTask);
            _context.SaveChanges();
            return View("~/Views/Home/Index.cshtml", _context.TrackingTasks.ToList());
        }
    }
}
