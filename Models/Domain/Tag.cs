using System.ComponentModel.DataAnnotations;

namespace Bloggie.Web.Models.Domain
{
    public class Tag
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? DisplayName { get; set; }
        public ICollection<blogPost> BlogPosts { get; set; }
    }
}
