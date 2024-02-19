using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Bloggie.Web.Models.Domain
{
    public class blogPost
    {
        public Guid Id { get; set; }  //since Guid is the unique identifier
        public string? Heading { get; set; }
        public string? PageTitle { get; set; }
        public string? Content { get; set; }
        public string? ShortDescription { get; set; }
        public string? FeaturedImageUrl { get; set; }
        public string? UrlHandle { get; set; }
        public DateTime PudlishedDate { get; set; }
        public string? Author { get; set; }
        public string? visible { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
