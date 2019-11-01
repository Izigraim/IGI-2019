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
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

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
            trackingTask.dateOfTaking = DateTime.Now;
            _context.TrackingTasks.Add(trackingTask);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
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

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ShowUser()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            List<TrackingTask> tt = new List<TrackingTask>();
            foreach(var task in _context.TrackingTasks)
            {
                if (task.whoTake == user) tt.Add(task);
            }
            TaskUserViewModel tuvm = new TaskUserViewModel { User = user, TrackingTasks = tt };
            return View(tuvm);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var task = await _context.TrackingTasks.FindAsync(id);
            _context.TrackingTasks.Remove(task);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles ="Admin,Manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var task = await _context.TrackingTasks.FindAsync(id);

            return View(task);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Edit(TrackingTask trackingTask)
        {
            _context.TrackingTasks.Update(trackingTask);
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult ShowUserTask(int? id)
        {
            if (id == null) return NotFound();

            var task = _context.TrackingTasks.Include(c => c.whoGave).Include(c => c.whoTake).Where(c => c.Id == id).First();

            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> ShowUserTask(TrackingTask trackingTask)
        {
            trackingTask.dateOfFinishing = DateTime.Now;
            trackingTask.whoTake = await _userManager.FindByNameAsync(User.Identity.Name);

            _context.TrackingTasks.Update(trackingTask);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> FinishTask(int? id)
        {
            if (id == null) return NotFound();

            var task = await _context.TrackingTasks.FindAsync(id);

            task.dateOfFinishing = DateTime.Now;
            _context.TrackingTasks.Update(task);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var task = await _context.TrackingTasks.FindAsync(id);
            List<TrackingTask> tt = new List<TrackingTask> { task };

            IndexViewModel ivm = new IndexViewModel { Users = _context.Users.ToList(), trackingTasks = tt };

            return View(ivm);
        }
    }
}
