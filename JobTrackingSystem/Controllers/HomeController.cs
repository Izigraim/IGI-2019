﻿using System;
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
using Microsoft.EntityFrameworkCore;

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
            IndexViewModel ivm = new IndexViewModel { trackingTasks = _context.TrackingTasks.ToList(), Users = _context.Users.ToList() };
            return View("~/Views/Home/Index.cshtml", ivm);
        }

        public async Task<IActionResult> TakeTask(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.TrackingTasks.FirstOrDefaultAsync(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            task.whoTake = await _userManager.FindByNameAsync(User.Identity.Name);
            _context.TrackingTasks.Update(task);
            await _context.SaveChangesAsync();

            List<TrackingTask> tt = new List<TrackingTask>() { task };
            TakingTasks takingTasks = new TakingTasks { User = task.whoTake, trackingTasks = tt };

            return View();
        }
    }
}
