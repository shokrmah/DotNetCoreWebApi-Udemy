using BookAPI.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BookAPI.Service
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Reviewer> Reviewers { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<BookAuthor> BookAuthors { get; set; }
        public virtual DbSet<BookCategory> BookCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookCategory>()
                .HasKey(bookCategory => new { bookCategory.BookId, bookCategory.CategoryId });

            modelBuilder.Entity<BookCategory>()
                .HasOne(book => book.Book)
                .WithMany(bookCategory => bookCategory.BookCategories)
                .HasForeignKey(book => book.BookId);

            modelBuilder.Entity<BookCategory>()
                .HasOne(category => category.Category)
                .WithMany(bookCategory => bookCategory.BookCategories)
                .HasForeignKey(category => category.CategoryId);

            modelBuilder.Entity<BookAuthor>()
                .HasKey(BookAuthor => new { BookAuthor.BookId, BookAuthor.AuthorId });

            modelBuilder.Entity<BookAuthor>()
             .HasOne(author => author.Author)
             .WithMany(BookAuthor => BookAuthor.BookAuthors)
             .HasForeignKey(author => author.AuthorId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(book => book.Book)
                .WithMany(BookAuthor => BookAuthor.BookAuthors)
                .HasForeignKey(book => book.BookId);

            modelBuilder.Entity<Country>()
                .HasMany(c => c.Authors)
                .WithOne(a => a.Country);
        }
    }
}
