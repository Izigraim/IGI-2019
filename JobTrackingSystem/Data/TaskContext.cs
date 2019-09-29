using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobTrackingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace JobTrackingSystem.Data
{
    public class TaskContext :DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {

        }
        public DbSet<TrackingTask> TrackingTask { get; set; }
    }
}
