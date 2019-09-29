using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace JobTrackingSystem.Models
{
    public class JobTrackingSystemContext : DbContext
    {
        public JobTrackingSystemContext (DbContextOptions<JobTrackingSystemContext> options)
            : base(options)
        {
        }

        public DbSet<JobTrackingSystem.Models.TrackingTask> TrackingTask { get; set; }
    }
}
