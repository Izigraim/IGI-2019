using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JobTrackingSystem.Data;
using JobTrackingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace JobTrackingSystem.Components
{
    public class UserTasksList : ViewComponent
    {
        TaskContext _context;
        public UserTasksList(TaskContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(User user)
        {
            var tasks = _context.TrackingTasks.Include(c => c.whoGave).Include(c => c.whoTake).Where(c => c.whoTake == user).ToList();
            return View(tasks);
        }
    }
}
