using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TestAppForFlycode.Common
{
    public class PostDTO
    {
        
        public int Id { get; set; }
        //[Column(TypeName = "nvarchar(50)")]
        public string Heading { get; set; } // заголовок
        //[Column(TypeName = "nvarchar(100)")]
        public string Description { get; set; } // Описание
        //[Column(TypeName = "varchar(100)")]
        public int DateOfCreation { get; set; } // дата создания
        //[Column(TypeName = "nvarchar(100)")]
        //[DisplayName("ImageTitle")]
        public string ImageTitle { get; set; }

        //[NotMapped]
        //[DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }

        public List<int> TagId { get; set; }

    }
}
