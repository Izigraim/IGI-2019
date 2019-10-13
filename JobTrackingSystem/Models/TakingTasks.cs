using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobTrackingSystem.Models;

namespace JobTrackingSystem.Models
{
    public class TakingTasks
    {
        public int Id { get; set; }

        public User User { get; set; }

        public ICollection<TrackingTask> trackingTasks { get; set; }
    }
}
