using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobTrackingSystem.Models;

namespace JobTrackingSystem.ViewModels
{
    public class ShowUserTaskViewModel
    {
        public User User { get; set; }
        public TrackingTask TrackingTask { get; set; }
    }
}
