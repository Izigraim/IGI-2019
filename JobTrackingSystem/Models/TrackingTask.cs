using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobTrackingSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace JobTrackingSystem.Models
{
    public class TrackingTask
    {
        public int Id { get; set; }
        public string whoGave { get; set; }
        public string whoTake { get; set; }
        public string taskName { get; set; }
        public string status { get; set; }
        [DataType(DataType.Date)]
        public DateTime dateOfTaking { get; set; }
        [DataType(DataType.Date)]
        public DateTime? dateOfFinishing { get; set; }

    }
}
