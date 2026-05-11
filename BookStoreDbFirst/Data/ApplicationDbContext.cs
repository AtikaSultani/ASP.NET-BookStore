using BookStoreDbFirst.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStoreDbFirst.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // paste here
            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Country).HasMaxLength(100);
                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasIndex(e => e.AuthorId, "IX_Books_AuthorId");

                entity.HasIndex(e => e.PublisherId, "IX_Books_PublisherId");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.Title).HasMaxLength(300);

                entity.HasOne(d => d.Author).WithMany(p => p.Books).HasForeignKey(d => d.AuthorId);

                entity.HasOne(d => d.Publisher).WithMany(p => p.Books).HasForeignKey(d => d.PublisherId);
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.Property(e => e.City).HasMaxLength(100);
                entity.Property(e => e.Name).HasMaxLength(200);
            });
        }
    }

}
