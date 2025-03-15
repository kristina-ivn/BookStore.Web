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
        public DbSet<BookGenre> BookGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BookGenre>().HasKey(bg => new { bg.IdGenre, bg.IdBook });

            builder.Entity<BookGenre>()
                .HasOne(b => b.Book)
                .WithMany(g => g.BookGenres)
                .HasForeignKey(b => b.IdBook);

            builder.Entity<BookGenre>()
               .HasOne(b => b.Genre)
               .WithMany(g => g.BookGenres)
               .HasForeignKey(b => b.IdGenre);

            base.OnModelCreating(builder);
        }
    }
}
