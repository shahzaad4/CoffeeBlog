using Coffee.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Coffee.Web.Data
{
    public class BlogDbContext:IdentityDbContext<IdentityUser>
    {
        public BlogDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Post> Posts { get; set; }

    }
}
