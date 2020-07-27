using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestAppForFlycode.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using TestAppForFlycode.Common;

namespace TestAppForFlycode.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;


        PostContext db;
       
        public HomeController(PostContext context, IWebHostEnvironment hostEnvironment)
        {
            db = context;
            this._hostEnvironment = hostEnvironment;
        }
        public async Task<IActionResult> Index()
        {

           
            return View(await db.Posts.ToListAsync());
        }

     
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id, Heading, Description, DateOfCreation, ImageTitle, ImageFile")] Post post)
        {
            if (ModelState.IsValid)
            {
                // сохрание изображения в wwwroot

                string wwwRootRath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(post.ImageFile.FileName);
                string extension = Path.GetExtension(post.ImageFile.FileName);
                post.ImageTitle = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootRath + "/image", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await post.ImageFile.CopyToAsync(fileStream);
                }

                var postDb = new Post
                {
                    DateOfCreation = post.DateOfCreation,
                    Description = post.Description,
                    Heading = post.Heading,
                    ImageFile = post.ImageFile,
                    ImageTitle = post.ImageTitle,
                };

                db.Posts.AddRange(postDb);
                db.SaveChanges();

                //var postTags = post.TagsIds.Select(item => new PostTag
                //{
                //    PostId = post.Id,
                //    TagsId = item,

                //});


                //db.PostsTags.AddRange(postTags);
                db.SaveChanges();

                return RedirectToAction(nameof (Index));
            }
            

            return View(/*posts*/);
        }

       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Post post = await db.Posts.FirstOrDefaultAsync(p => p.PostId == id);
                if (post != null)
                    return View(post);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Post post)
        {
            db.Posts.Update(post);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Post post = await db.Posts.FirstOrDefaultAsync(p => p.PostId == id);
                if (post != null)
                    db.Posts.Remove(post);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return NotFound();
        }

        // для тегов

      
        //[HttpPost]

        //public int SavePost([FromBody] PostDTO dto)
        //{
           
        //    var post = new Post
        //    {
        //        DateOfCreation = dto.DateOfCreation, 
        //        Description = dto.Description,
        //        Heading = dto.Heading,
        //        ImageFile = dto.ImageFile,
        //        ImageTitle = dto.ImageTitle,

        //    };
        //    db.Posts.AddRange(post);
        //    db.SaveChanges();

        //    var postTags = dto.TagsIds.Select(item => new PostTag
        //    {
        //        PostId = post.PostId,
        //        TagId = item,
                                
        //    });
                        
        //    db.PostTags.AddRange(postTags);
        //    db.SaveChanges();

        //    return  post.Id;
        //}
       
    }
}
