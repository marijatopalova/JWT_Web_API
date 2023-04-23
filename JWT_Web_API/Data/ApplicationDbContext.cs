using JWT_Web_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace JWT_Web_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
    }
}
