using Microsoft.EntityFrameworkCore;
using Minimo.Models;

namespace Minimo.Data {
    public class MainDbContext : DbContext {
        public DbSet<Post>? Posts { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Image>? Images { get; set; }
        public DbSet<Comment>? Comments { get; set; }

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
