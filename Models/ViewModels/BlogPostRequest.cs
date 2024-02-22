namespace Bloggie.Web.Models.ViewModels
{
    public class BlogPostRequest
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
    }
}
