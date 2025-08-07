using Coffee.Web.Models;

namespace Coffee.Web.Repositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllAsync();
        Task<Post?> GetByIdAsync(Guid id);
        Task<Post?> GetBySlugAsync(string slug);
        Task<Post> AddAsync(Post post);
        Task<Post> UpdateAsync(Guid id,Post post);
        Task<bool> DeleteAsync(Guid id);



    }
}
