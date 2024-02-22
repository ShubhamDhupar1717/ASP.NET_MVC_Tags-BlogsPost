using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Bloggie.Web.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly BloggieDbContext _bloggieDbContext;
        public TagRepository(BloggieDbContext bloggieDbContext)
        {
            _bloggieDbContext = bloggieDbContext;
        }


        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            var list = await _bloggieDbContext.Tags.ToListAsync();
            return list;
        }

        public async Task<Tag> GetSingleTagAsync(Guid id)
        {
            var tag = await _bloggieDbContext.Tags.FirstOrDefaultAsync(m => m.Id == id);
            return tag;
        }

        public async Task<Tag> AddTagAsync(Tag tag)
        {
            await _bloggieDbContext.AddAsync(tag);
            await _bloggieDbContext.SaveChangesAsync();
            return tag;
        }
        public  Task<Tag> GetUpdateTagAsync(Guid id)
        {
            throw new NotImplementedException();
            //var tag = await _bloggieDbContext.Tags.FindAsync(id);

            //if (tag != null)
            //{
            //    var tagRequest = new TagRequest
            //    {
            //        Id = id,
            //        Name = tag.Name,
            //        DisplayName = tag.DisplayName
            //    };
            //    return View(tagRequest);
            //}
            //return View(null);
        }

        public Task<Tag> PostUpdateTagAsync(Guid id, Tag tag)
        {
            throw new NotImplementedException();

        }

        public  Task<Tag> DeleteTagAsync(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
