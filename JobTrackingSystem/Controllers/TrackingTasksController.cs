using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobTrackingSystem.Models;

namespace JobTrackingSystem.Controllers
{
    public class TrackingTasksController : Controller
    {
        private readonly JobTrackingSystemContext _context;

        public TrackingTasksController(JobTrackingSystemContext context)
        {
            _context = context;
        }

        // GET: TrackingTasks
        public async Task<IActionResult> Index()
        {
            return View(await _context.TrackingTask.ToListAsync());
        }

    }
}
