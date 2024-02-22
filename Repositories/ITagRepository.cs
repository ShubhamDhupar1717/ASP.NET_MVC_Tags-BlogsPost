using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.Repositories
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetAllAsync();
        Task<Tag> GetSingleTagAsync(Guid id);
        Task<Tag> AddTagAsync(Tag tag);
        Task<Tag> GetUpdateTagAsync(Guid id);
        Task<Tag> PostUpdateTagAsync(Guid id, Tag tag);
        Task<Tag> DeleteTagAsync(Guid id);
    }
}
