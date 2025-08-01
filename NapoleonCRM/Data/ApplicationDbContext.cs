using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NapoleonCRM.Models;
using NapoleonCRM.Shared.Models;

namespace NapoleonCRM.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Customer> Customer => Set<Customer>();

    public override int SaveChanges()
    {
        UpdateTimestamps();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateTimestamps();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateTimestamps()
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is Customer && (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entry in entries)
        {
            var customer = (Customer)entry.Entity;

            if (entry.State == EntityState.Added)
            {
                customer.CreatedDate ??= DateTime.UtcNow; // Set only if null
            }

            customer.ModifiedDate = DateTime.UtcNow; // Always set for both Added and Modified
        }
    }

    public DbSet<Address> Address => Set<Address>();
    public DbSet<ProductCategory> ProductCategory => Set<ProductCategory>();
    public DbSet<ServiceCategory> ServiceCategory => Set<ServiceCategory>();
    public DbSet<Contact> Contact => Set<Contact>();
    public DbSet<Opportunity> Opportunity => Set<Opportunity>();
    public DbSet<Lead> Lead => Set<Lead>();
    public DbSet<Product> Product => Set<Product>();
    public DbSet<Service> Service => Set<Service>();
    public DbSet<Sale> Sale => Set<Sale>();
    public DbSet<Vendor> Vendor => Set<Vendor>();
    public DbSet<SupportCase> SupportCase => Set<SupportCase>();
    public DbSet<TodoTask> TodoTask => Set<TodoTask>();
    public DbSet<Reward> Reward => Set<Reward>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Customer>()
            .HasOne(x => x.Address);
        modelBuilder.Entity<Customer>()
            .HasMany(x => x.Contact);
        modelBuilder.Entity<Contact>()
            .HasOne(x => x.Address);
        modelBuilder.Entity<Contact>()
            .HasMany(x => x.Reward);
        modelBuilder.Entity<Lead>()
            .Property(e => e.PotentialValue)
            .HasConversion<double>();
        modelBuilder.Entity<Lead>()
            .Property(e => e.PotentialValue)
            .HasPrecision(19, 4);
        modelBuilder.Entity<Lead>()
            .HasOne(x => x.Address);
        modelBuilder.Entity<Lead>()
            .HasOne(x => x.Opportunity);
        modelBuilder.Entity<Lead>()
            .HasOne(x => x.Contact);
        modelBuilder.Entity<Product>()
            .Property(e => e.Price)
            .HasConversion<double>();
        modelBuilder.Entity<Product>()
            .Property(e => e.Price)
            .HasPrecision(19, 4);
        modelBuilder.Entity<Product>()
            .HasMany(x => x.ProductCategory);
        modelBuilder.Entity<Service>()
            .HasMany(x => x.ServiceCategory);
        modelBuilder.Entity<Sale>()
            .Property(e => e.TotalAmount)
            .HasConversion<double>();
        modelBuilder.Entity<Sale>()
            .Property(e => e.TotalAmount)
            .HasPrecision(19, 4);
        modelBuilder.Entity<Vendor>()
            .HasOne(x => x.Address);
        modelBuilder.Entity<Vendor>()
            .HasMany(x => x.Product);
        modelBuilder.Entity<Vendor>()
            .HasMany(x => x.Service);
        modelBuilder.Entity<Reward>()
            .Property(e => e.CreditsDollars)
            .HasConversion<double>();
        modelBuilder.Entity<Reward>()
            .Property(e => e.CreditsDollars)
            .HasPrecision(19, 4);
        modelBuilder.Entity<Reward>()
            .Property(e => e.ConversionRate)
            .HasConversion<double>();
        modelBuilder.Entity<Reward>()
            .Property(e => e.ConversionRate)
            .HasPrecision(19, 4);
    }
}
