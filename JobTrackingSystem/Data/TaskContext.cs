using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JobTrackingSystem.Models;

namespace JobTrackingSystem.Data
{
    public class TaskContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TrackingTask> TrackingTasks { get; set; }        

        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
