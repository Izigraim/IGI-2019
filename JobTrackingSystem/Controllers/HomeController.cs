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
using Microsoft.AspNetCore.SignalR;

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

        public async Task<IActionResult> Index(int? trackingTask, string name, SortState sortOrder = SortState.dateOfTakingAsc, int page = 1)
        {
            int pageSize = 5;
            //----фильтр---
            IQueryable<TrackingTask> trackingTasks = _context.TrackingTasks.Include(c => c.whoGave).Include(c => c.whoTake);
            if (trackingTask != null && trackingTask != 0)
            {
                trackingTasks = trackingTasks.Where(p => p.Id == trackingTask);
            }
            if(!String.IsNullOrEmpty(name))
            {
                trackingTasks = trackingTasks.Where(p => p.ShortDescription.Contains(name));
            }
            //-----------

            //----сортировка---
            switch(sortOrder)
            {
                case SortState.dateofTakingDesc:
                    trackingTasks = trackingTasks.OrderByDescending(s => s.dateOfTaking);
                    break;
                default:
                    trackingTasks = trackingTasks.OrderBy(s => s.dateOfTaking);
                    break;
            }
            //------------

            //----пагинация---
            var count = await trackingTasks.CountAsync();
            var items = await trackingTasks.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            //------------

            IndexViewModel ivm = new IndexViewModel
            {
                trackingTasks = items,
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(_context.TrackingTasks.ToList(), trackingTask, name),
                Users = _context.Users.ToList()
            };

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
            trackingTask.status = "Доступно";
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
            task.status = "Выполняется";
            _context.TrackingTasks.Update(task);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ShowUser()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var tasks = _context.TrackingTasks.Include(c => c.whoGave).Include(c => c.whoTake).Where(c => c.whoTake == user);
            ViewBag.User = user;
            //List<TrackingTask> tt = new List<TrackingTask>();
            //foreach(var task in _context.TrackingTasks)
            //{
            //    if (task.whoTake == user) tt.Add(task);
            //}
            //TaskUserViewModel tuvm = new TaskUserViewModel { User = user, TrackingTasks = tt };
            return View(tasks);
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
            trackingTask.status = "Обрабатывается";

            _context.TrackingTasks.Update(trackingTask);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var task = _context.TrackingTasks.Include(c => c.whoGave).Include(c => c.whoTake).Where(c => c.Id == id).First();

            return View(task);
        }

        public async Task<IActionResult> Confirm(int? id)
        {
            if (id == null) return NotFound();

            var task = _context.TrackingTasks.Include(c => c.whoGave).Include(c => c.whoTake).Where(c => c.Id == id).First();
            task.status = "Выполнено";

            _context.TrackingTasks.Update(task);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Deny(int? id)
        {
            if (id == null) return NotFound();

            var task = _context.TrackingTasks.Include(c => c.whoGave).Include(c => c.whoTake).Where(c => c.Id == id).First();
            task.status = "Выполняется";
            task.dateOfFinishing = null;

            _context.TrackingTasks.Update(task);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeclineTask(int? id)
        {
            if (id == null) return NotFound();

            var task = _context.TrackingTasks.Include(c => c.whoGave).Include(c => c.whoTake).Where(c => c.Id == id).First();
            task.status = "Доступно";
            task.whoTake = null;

            _context.TrackingTasks.Update(task);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
            
        }
    }

}
