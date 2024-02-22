using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;

namespace Bloggie.Web.Controllers
{
    public class AdminBlogPostController : Controller
    {
        private readonly BloggieDbContext _context;

        public AdminBlogPostController(BloggieDbContext context)
        {
            _context = context;
        }

        // GET: AdminBlogPost
        public async Task<IActionResult> Index()
        {
              return _context.BlogPosts != null ? View(await _context.BlogPosts.ToListAsync()) : Problem("Entity set 'BloggieDbContext.BlogPosts'  is null.");
        }


        // GET: AdminBlogPost/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.BlogPosts == null)
            {
                return NotFound();
            }

            var blogPost = await _context.BlogPosts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogPost == null)
            {
                return NotFound();
            }

            return View(blogPost);
        }


        // GET: AdminBlogPost/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: AdminBlogPost/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Heading,PageTitle,Content,ShortDescription,FeaturedImageUrl,UrlHandle,PudlishedDate,Author,visible")] BlogPostRequest blogPostRequest)
        {
            //if (ModelState.IsValid)
            //{
            if(blogPostRequest != null)
            {
                var blog = new blogPost
                {
                    Heading = blogPostRequest.Heading,
                    PageTitle = blogPostRequest.PageTitle,
                    Content = blogPostRequest.Content,
                    ShortDescription = blogPostRequest.ShortDescription,
                    FeaturedImageUrl = blogPostRequest.FeaturedImageUrl,
                    UrlHandle = blogPostRequest.UrlHandle,
                    PudlishedDate = blogPostRequest.PudlishedDate,
                    Author = blogPostRequest.Author,
                    visible = blogPostRequest.visible,
                };
                    _context.Add(blog);
            }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            //}
            //return View(blogPost);
        }


        // GET: AdminBlogPost/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.BlogPosts == null)
            {
                return NotFound();
            }

            var blogPost = await _context.BlogPosts.FindAsync(id);
            if (blogPost == null)
            {
                return NotFound();
            }
            return View(blogPost);
        }


        // POST: AdminBlogPost/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Heading,PageTitle,Content,ShortDescription,FeaturedImageUrl,UrlHandle,PudlishedDate,Author,visible")] blogPost blogPost)
        {
            if (id != blogPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!blogPostExists(blogPost.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(blogPost);
        }


        // GET: AdminBlogPost/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.BlogPosts == null)
            {
                return NotFound();
            }

            var blogPost = await _context.BlogPosts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogPost == null)
            {
                return NotFound();
            }

            return View(blogPost);
        }


        // POST: AdminBlogPost/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.BlogPosts == null)
            {
                return Problem("Entity set 'BloggieDbContext.BlogPosts'  is null.");
            }
            var blogPost = await _context.BlogPosts.FindAsync(id);
            if (blogPost != null)
            {
                _context.BlogPosts.Remove(blogPost);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool blogPostExists(Guid id)
        {
          return (_context.BlogPosts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
