using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAppForFlycode.Models
{
    public class SampleData
    {
        public static void Initialize(PostContext context)
        {
            if (!context.Posts.Any())
            {
                context.Posts.AddRange(
                    new Post
                    {
                        Heading = "Новости",
                        Description = "Россия победила COVID",
                        DateOfCreation = 2020
                    }

                   
                );
               
                context.SaveChanges();
            }


        
        }
    }
}
