using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BookStore.Web.Data.Entity;

namespace BookStore.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Author> Author { get; set; } = default!;
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genre { get; set; } = default!;
    }
}
