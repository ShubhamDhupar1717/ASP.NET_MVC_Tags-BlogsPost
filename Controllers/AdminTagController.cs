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
using NuGet.Protocol.Plugins;
using Azure;

namespace Bloggie.Web.Controllers
{
    public class AdminTagController : Controller
    {
        private readonly BloggieDbContext _context;

        public AdminTagController(BloggieDbContext context)
        {
            _context = context;
        }

        // GET: AdminTag
        public async Task<IActionResult> Index()
        {
              return _context.Tags != null ? View(await _context.Tags.ToListAsync()) : Problem("Entity set 'BloggieDbContext.Tags'  is null.");
        }

        // GET: AdminTag/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (_context.Tags == null)
            {
                return NotFound();
            }

            var tag = await _context.Tags
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }


        // GET: AdminTag/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminTag/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DisplayName")] TagRequest tagRequest)
        {
            var tag = new Tag
            {
                Name = tagRequest.Name,
                DisplayName = tagRequest.DisplayName
            };
            //if (ModelState.IsValid)
            //{
            _context.Add(tag);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            //}
            //return View(tag);
        }


        public async Task<IActionResult> Edit(Guid id)
        {
            if (_context.Tags == null)
            {
                return NotFound();
            }

            var tag = await _context.Tags.FindAsync(id);

            if (tag != null)
            {
                var tagRequest = new TagRequest
                { 
                    Id = id,
                    Name = tag.Name,
                    DisplayName = tag.DisplayName
                };
            return View(tagRequest);
            }
            return View(null);
        }

        // POST: AdminTag/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,DisplayName")] TagRequest tagRequest)
        {
            if (id != tagRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var tag = new Tag
                    {
                        Id = id,
                        Name = tagRequest.Name,
                        DisplayName = tagRequest.DisplayName
                    };

                    _context.Update(tag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TagExists(tagRequest.Id))
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
            return View(tagRequest);
        }



        // GET: AdminTag/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (_context.Tags == null)
            {
                return NotFound();
            }

            var tag = await _context.Tags
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }

        // POST: AdminTag/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Tags == null)
            {
                return Problem("Entity set 'BloggieDbContext.Tags'  is null.");
            }
            var tag = await _context.Tags.FindAsync(id);
            if (tag != null)
            {
                _context.Tags.Remove(tag);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TagExists(Guid id)
        {
          return (_context.Tags?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
