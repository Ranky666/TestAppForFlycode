using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAppForFlycode.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Heading { get; set; } // загаловок

        public string Description { get; set; } // Описание

        public int DateOfCreation { get; set; } // дата создания

        public  Post()
        {
            Tags = new HashSet<PostTag>();
        }

        public virtual ICollection<PostTag> Tags { get; set; }


    }
}
