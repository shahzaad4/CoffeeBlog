using Coffee.Web.Data;
using Coffee.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Coffee.Web.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogDbContext context;

        public PostRepository(BlogDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await context.Posts.OrderByDescending(p=>p.CreatedAt).ToListAsync();
        }
        public async Task<Post?> GetByIdAsync(Guid id)
        {
            return await context.Posts.FindAsync(id);
        }
        public async Task<Post?> GetBySlugAsync(string slug)
        {
            return await context.Posts.FirstOrDefaultAsync(p => p.Slug == slug);
        }
        public async Task<Post> AddAsync(Post post)
        {
            context.Posts.Add(post);
            await context.SaveChangesAsync();
            return post;
        }
        public async Task<Post?> UpdateAsync(Guid id,Post post)
        {
            var existing = await context.Posts.FindAsync(id);
            if (existing != null)
            {
                existing.Title = post.Title;
                existing.Content = post.Content;
                existing.UpdatedAt = DateTime.UtcNow;

                await context.SaveChangesAsync();
                return existing;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var post = await context.Posts.FindAsync(id);
            if(post != null)
            {
                context.Posts.Remove(post);
                await context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;

            }
        }



    }
}
