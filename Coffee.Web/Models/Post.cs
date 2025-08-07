using System.ComponentModel.DataAnnotations;

namespace Coffee.Web.Models
{
    public class Post
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [MaxLength(200)]
        public string Slug { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
