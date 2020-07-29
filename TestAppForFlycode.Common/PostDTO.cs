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
        public string Heading { get; set; } // заголовок
        public string Description { get; set; } // Описание
        public int DateOfCreation { get; set; } // дата создания
        public string ImageTitle { get; set; }
        public IFormFile ImageFile { get; set; }
        public List<int> TagId { get; set; }

    }
}
