using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobTrackingSystem.Data;
using JobTrackingSystem.Models;

namespace JobTrackingSystem
{
    public static class SampleData
    {
        public static void Initialize(TaskContext context)
        {
            if(!context.Users.Any())
            {
                context.Users.AddRange(
                    new User
                    {
                        first_name = "Ivan",
                        last_name = "Ivanov",
                        nickname = "Admin"
                    },
                    new User
                    {
                        first_name = "Nikolay",
                        last_name = "Nikolayev",
                        nickname = "User1"
                    },
                    new User
                    {
                        first_name = "Petr",
                        last_name = "Petrov",
                        nickname = "User2"
                    }
                    );
                context.SaveChanges();
            }
            if (!context.TrackingTasks.Any())
            {
                context.TrackingTasks.AddRange(
                    new TrackingTask
                    {
                        taskName = "1",
                        status = "1",
                        whoGave = context.Users.First(),
                        whoTake = context.Users.Last(),
                        dateOfTaking = DateTime.Parse("2019-9-25"),
                        dateOfFinishing = null

                    },
                    new TrackingTask
                    {
                        taskName = "2",
                        status = "2",
                        whoGave = context.Users.First(),
                        whoTake = context.Users.First(s => s.Id == 2),
                        dateOfTaking = DateTime.Parse("2019-9-25"),
                        dateOfFinishing = DateTime.Parse("2019-9-28")
                    },
                    new TrackingTask
                    {
                        taskName = "3",
                        status = "3",
                        whoGave = context.Users.First(),
                        whoTake = context.Users.Last(),
                        dateOfTaking = DateTime.Parse("2019-9-22"),
                        dateOfFinishing = null
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
