using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestAppForFlycode.Models;
using Microsoft.EntityFrameworkCore;

using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace TestAppForFlycode.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;


        PostContext db;
        //private IWebHostEnvironment hostEnvironment;

        public HomeController(PostContext context, IWebHostEnvironment hostEnvironment)
        {
            db = context;
            this._hostEnvironment = hostEnvironment;
        }
        public async Task<IActionResult> Index()
        {

           
            return View(await db.Posts.ToListAsync());
        }

        public async Task<IActionResult> GetTag(string tags)
        {
            var query =
                        from post in db.Posts
                        where tags.All(requiredId => post.Tags.Any(tag => tag.TagsId == requiredId))
                        select post;


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

                db.Posts.Add(post);

                await db.SaveChangesAsync();
                return RedirectToAction(nameof (Index));
            }

            return View(post);
        }

       

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Post post = await db.Posts.FirstOrDefaultAsync(p => p.Id == id);
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
                Post post = await db.Posts.FirstOrDefaultAsync(p => p.Id == id);
                if (post != null)
                    db.Posts.Remove(post);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return NotFound();
        }

        //public IActionResult UploadImage()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult UploadImage(Post post)
        //{
        //    foreach (var file in Request.Form.Files)
        //    {
        //        Post img = new Post();
        //        img.ImageTitle = file.FileName;

        //        MemoryStream ms = new MemoryStream();
        //        file.CopyTo(ms);
        //        img.ImageData = ms.ToArray();

        //        ms.Close();
        //        ms.Dispose();

        //        db.Posts.Add(post);
        //        db.SaveChanges();
        //    }

        //    return View("Index");
        //}

    }
}
