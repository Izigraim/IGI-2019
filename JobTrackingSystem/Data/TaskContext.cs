using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JobTrackingSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace JobTrackingSystem.Data
{
    public class TaskContext : IdentityDbContext<User>
    {
        public DbSet<TrackingTask> TrackingTasks { get; set; }        
        public DbSet<TakingTasks> TakingTasks { get; set; }

        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
        }
    }
}
