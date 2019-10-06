using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JobTrackingSystem.Models;
using JobTrackingSystem.Data;
using JobTrackingSystem.ViewModels;

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
            IndexViewModel ivm = new IndexViewModel { trackingTasks = _context.TrackingTasks.ToList(), Users = _context.Users.ToList() };
            return View(ivm);
        } 

        [HttpGet]
        public IActionResult Create()
        {
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
