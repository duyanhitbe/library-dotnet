using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<BookEntity> Books { get; set; }
    public DbSet<BookInfoEntity> BookInfos { get; set; }
    public DbSet<BorrowerEntity> Borrowers { get; set; }
    public DbSet<UserEntity> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //Category
        modelBuilder.Entity<CategoryEntity>()
            .HasMany(e => e.Books)
            .WithOne(e => e.Category)
            .HasForeignKey(e => e.CategoryId)
            .IsRequired();

        //Book
        modelBuilder.Entity<BookEntity>()
            .HasOne(e => e.Category)
            .WithMany(e => e.Books)
            .HasForeignKey(e => e.CategoryId)
            .IsRequired();
        modelBuilder.Entity<BookEntity>()
            .HasOne(e => e.BookInfo)
            .WithOne(e => e.Book)
            .HasForeignKey<BookEntity>(e => e.BookInfoId)
            .IsRequired();
        modelBuilder.Entity<BookEntity>()
            .HasMany(e => e.Borrowers)
            .WithMany(e => e.Books)
            .UsingEntity(
                "book_borrower",
                j =>
                {
                    j.Property("BooksId").HasColumnName("book_id");
                    j.Property("BorrowersId").HasColumnName("borrower_id");
                });

        //Borrower
        modelBuilder.Entity<BorrowerEntity>()
            .HasMany(e => e.Books)
            .WithMany(e => e.Borrowers)
            .UsingEntity("book_borrower");
    }
}