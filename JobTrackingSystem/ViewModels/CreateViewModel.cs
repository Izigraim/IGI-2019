using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobTrackingSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JobTrackingSystem.ViewModels
{
    public class CreateViewModel
    {
        public SelectList Users { get; set; }
        public TrackingTask trackingTask { get; set; }
    }
}
