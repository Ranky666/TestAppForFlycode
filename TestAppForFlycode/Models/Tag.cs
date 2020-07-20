using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAppForFlycode.Models
{
    public class Tag
    {

        public int Id { get; set; }

        public string TagName { get; set; }


        public Tag()
        {
            Posts = new HashSet<PostTag>();
        }

        public virtual ICollection<PostTag> Posts { get; set; }
    }
}
