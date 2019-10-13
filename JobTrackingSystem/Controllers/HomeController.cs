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
using Microsoft.AspNetCore.Identity;

namespace JobTrackingSystem.Controllers
{
    public class HomeController : Controller
    {
        TaskContext _context;
        UserManager<User> _userManager;
        public HomeController(TaskContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
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
        public async Task<IActionResult> Create(TrackingTask trackingTask)
        {
            trackingTask.whoGave = await _userManager.FindByNameAsync(User.Identity.Name);
            _context.TrackingTasks.Add(trackingTask);
            _context.SaveChanges();
            return View("~/Views/Home/Index.cshtml", _context.TrackingTasks.ToList());
        }
    }
}
