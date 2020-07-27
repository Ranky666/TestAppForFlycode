using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAppForFlycode.Models
{
    public class PostTag
    {

        public int PostId { get; set; }
        public string TagId { get; set; }

        public  Post Post { get; set; }
        public  Tag Tag { get; set; }


    }
}
