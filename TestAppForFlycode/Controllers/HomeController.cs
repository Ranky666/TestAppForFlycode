using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestAppForFlycode.Models;
using Microsoft.EntityFrameworkCore;

using AutoMapper;

namespace TestAppForFlycode.Controllers
{
    public class HomeController : Controller
    {

       
        PostContext db;
        public HomeController(PostContext context)
        {
            db = context;
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
        public async Task<IActionResult> Create(Post post)
        {
            db.Posts.Add(post);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
        public async Task<IActionResult> ConfirmDelete(int? id)
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


    }
}
