using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobTrackingSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JobTrackingSystem.ViewModels
{
    public class FilterViewModel
    {
        public FilterViewModel(List<TrackingTask> trackingTasks, int? trackingTask, string name)
        {
            SelectedTask = trackingTask;
            SelectedName = name;

        }

        public int? SelectedTask { get; private set; }
        public string SelectedName { get; private set; }
    }
}
