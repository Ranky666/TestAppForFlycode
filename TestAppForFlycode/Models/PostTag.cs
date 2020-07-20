using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAppForFlycode.Models
{
    public class PostTag
    {

        public int Id { get; set; }
        public int PostId { get; set; }
        public int TagsId { get; set; }

        public  Post post { get; set; }
        public  Tag tag { get; set; }


    }
}
