using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobTrackingSystem.Models;

namespace JobTrackingSystem.Models
{
    public class Task
    {
        private User whoGave { get; set; }
        private User whoTake { get; set; }
        private string taskName { get; set; }
        private string status { get; set; }
        private string dateOfTaking { get; set; }
        private string dateOfFinishing { get; set; }
    }
}
