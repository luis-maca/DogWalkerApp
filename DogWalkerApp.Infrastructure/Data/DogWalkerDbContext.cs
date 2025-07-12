using Microsoft.EntityFrameworkCore;
using DogWalkerApp.Domain.Entities;

namespace DogWalkerApp.Infrastructure.Data;

public class DogWalkerDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Dog> Dogs { get; set; }
    public DbSet<DogWalk> DogWalks { get; set; }
    public DbSet<Walker> Walkers { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<AppConfiguration> AppConfigurations { get; set; }

    public DogWalkerDbContext(DbContextOptions<DogWalkerDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>()
            .HasMany(c => c.Dogs)
            .WithOne(d => d.Client)
            .HasForeignKey(d => d.ClientId);

        modelBuilder.Entity<Client>()
            .HasOne(c => c.Subscription)
            .WithOne(s => s.Client)
            .HasForeignKey<Subscription>(s => s.ClientId);

        modelBuilder.Entity<Dog>()
            .HasMany(d => d.Walks)
            .WithOne(w => w.Dog)
            .HasForeignKey(w => w.DogId);

        modelBuilder.Entity<Walker>()
            .HasMany(w => w.Walks)
            .WithOne(dw => dw.Walker)
            .HasForeignKey(dw => dw.WalkerId);

        modelBuilder.Entity<Subscription>()
            .HasMany(s => s.Payments)
            .WithOne(p => p.Subscription)
            .HasForeignKey(p => p.SubscriptionId);

        // ENUM Mappings for this entities to store string insted of int
        modelBuilder.Entity<Subscription>()
            .Property(s => s.Frequency)
            .HasConversion<string>();

        modelBuilder.Entity<Payment>()
            .Property(p => p.Method)
            .HasConversion<string>();

        modelBuilder.Entity<Dog>()
            .Property(d => d.Breed)
            .HasConversion<string>();

        base.OnModelCreating(modelBuilder);
    }


    public override int SaveChanges()
    {
        ApplyAuditableInformation();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyAuditableInformation();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void ApplyAuditableInformation()
    {
        var entries = ChangeTracker.Entries<BaseEntity>();

        foreach (var entry in entries)
        {
            var now = DateTime.UtcNow;
            var user = "SYSTEM"; // A default user since this solution does not include user management

            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = user;
                    entry.Entity.CreatedDate = now;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedBy = user;
                    entry.Entity.UpdatedDate = now;
                    break;
            }
        }
    }
}
