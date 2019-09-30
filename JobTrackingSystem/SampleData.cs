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
        }
    }
}
