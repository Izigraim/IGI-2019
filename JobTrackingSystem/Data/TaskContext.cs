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

        public DbSet<ToDoItem> toDoItems { get; set; }

        public DbSet<Logs> logs { get; set; }

        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().HasMany(t => t.TrackingTasks).WithOne(g => g.whoTake).HasForeignKey(g => g.whoTakeId);
        }
    }
}
