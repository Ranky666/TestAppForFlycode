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
            if (!context.Tags.Any())
            {
                context.Tags.AddRange(
                   new Tag
                   {
                     TagName = "Новости",
                     TagId = "1"
                   },
                   new Tag
                   {
                     TagName = "Реклама",
                     TagId ="2"
                   },
                   new Tag
                   {
                     TagName = "Погода",
                     TagId ="3"
                   }

               );

                context.SaveChanges();
            }
                    
        }
    }
}
