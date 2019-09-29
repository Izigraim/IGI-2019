using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobTrackingSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        private string first_name { get; set; }
        private string last_name { get; set; }
        private string nickname { get; set; }
    }
}
