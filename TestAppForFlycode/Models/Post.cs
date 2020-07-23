using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestAppForFlycode.Models
{
    public  class Post
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Heading { get; set; } // загаловок
        [Column(TypeName = "nvarchar(100)")]
        public string Description { get; set; } // Описание
        [Column(TypeName = "varchar(100)")]
        public int DateOfCreation { get; set; } // дата создания
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("ImageTitle")]
        public string ImageTitle { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public  IFormFile ImageFile { get; set; }
   

        public  Post()
        {
            Tags = new HashSet<PostTag>();
        }

        public virtual ICollection<PostTag> Tags { get; set; }


    }
}
