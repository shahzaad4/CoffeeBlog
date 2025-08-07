using Microsoft.IdentityModel.Tokens;

namespace Coffee.Web.DTOs
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreatePostDto
    {
        public string Title { get; set; }
        public string Content { get; set; }

    }

    public class UpdatePostDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }


    }
}
