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
        public User whoGave { get; set; }
        public string whoTakeId { get; set; }
        public User whoTake { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string status { get; set; }
        [DataType(DataType.Date)]
        public DateTime dateOfTaking { get; set; }
        [DataType(DataType.Date)]
        public DateTime? dateOfFinishing { get; set; }


    }
}
