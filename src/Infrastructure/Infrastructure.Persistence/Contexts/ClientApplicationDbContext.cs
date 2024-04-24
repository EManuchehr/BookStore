using System.Reflection;
using Application.Client.Common.Interfaces;
using Domain.Common.BaseEntities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Contexts;

public class ClientApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<City> Cities { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Genre> BookGenres { get; set; } = null!;
    public DbSet<Country> Countries { get; set; } = null!;
    public DbSet<Location> Locations { get; set; } = null!;
    public DbSet<OrderItem> OrderItems { get; set; } = null!;
    public DbSet<Copyright> Copyrights { get; set; } = null!;
    public DbSet<Publisher> Publishers { get; set; } = null!;
    public DbSet<BookAuthor> BookAuthors { get; set; } = null!;
    public DbSet<BookReview> BookReviews { get; set; } = null!;
    public DbSet<Category> BookCategories { get; set; } = null!;
    public DbSet<ShippingAddress> ShippingAddresses { get; set; } = null!;

    public ClientApplicationDbContext(DbContextOptions<ClientApplicationDbContext> options) : base(options)
    {
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDateTime = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedDateTime = DateTime.Now;
                    break;
            }
        }

        foreach (var entry in ChangeTracker.Entries<UserAuditableBaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDateTime = DateTime.Now;
                    entry.Entity.CreatedByUserId = Guid.Empty;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedDateTime = DateTime.Now;
                    entry.Entity.UpdatedByUserId = Guid.Empty;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.HasDefaultSchema("BookStore");
    }
}