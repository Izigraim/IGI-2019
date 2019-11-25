using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobTrackingSystem.Models
{
    public class ToDoItem
    {
        public long Id { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
