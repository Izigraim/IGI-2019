using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobTrackingSystem.Models;

namespace JobTrackingSystem.ViewModels
{
    public class TaskUserViewModel
    {
        public User User { get; set; }
        public IEnumerable<TrackingTask> TrackingTasks { get; set; }
    }
}
