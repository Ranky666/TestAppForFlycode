using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAppForFlycode.Models
{
    public class Tag
    {

        public string TagId { get; set; }

        public string TagName { get; set; }

        public virtual List<PostTag> PostTags { get; set; }
    }
}
