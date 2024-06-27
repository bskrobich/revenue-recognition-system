using Microsoft.EntityFrameworkCore;
using RevenueRecognitionSystem.Models;
using RevenueRecognitionSystem.Models.Clients;
using RevenueRecognitionSystem.Models.Software;

namespace RevenueRecognitionSystem.Contexts;

public class DatabaseContext : DbContext
{
    public DbSet<PersonClient> People { get; set; }
    public DbSet<CompanyClient> Companies { get; set; }
    public DbSet<Software> Software { get; set; }
    public DbSet<SoftwareVersion> Versions { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<User> Users { get; set; }
    
    protected DatabaseContext()
    {
        
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PersonClient>()
            .HasQueryFilter(p => !p.IsDeleted);

        modelBuilder.Entity<PersonClient>()
            .Property(p => p.IsDeleted)
            .HasColumnName("IsDeleted")
            .HasColumnType("bit")
            .HasDefaultValue(false);

        modelBuilder.Entity<PersonClient>().HasData(
            new List<PersonClient>
            {
                new PersonClient
                {
                    Id = 1,
                    PESEL = "12345678901",
                    FirstName = "John",
                    LastName = "Doe",
                    Address = "Koszykowa 86, 02-008 Warsaw",
                    Email = "john.doe@gmail.com",
                    PhoneNumber = "123456789"
                },
                new PersonClient
                {
                    Id = 2,
                    PESEL = "01987654321",
                    FirstName = "Jane",
                    LastName = "Doe",
                    Address = "plac Politechniki 1, 00-661 Warsaw",
                    Email = "jane.doe@gmail.com",
                    PhoneNumber = "987654321"
                }
            }
        );

        modelBuilder.Entity<CompanyClient>().HasData(
            new List<CompanyClient>
            {
                new CompanyClient
                {
                    Id = 1,
                    KRS = "000123456789",
                    Name = "Tech Company",
                    Address = "rondo Daszyńskiego 2, 00-843 Warsaw",
                    Email = "contact@techcompany.com",
                    PhoneNumber = "123456789"
                },
                new CompanyClient
                {
                    Id = 2,
                    KRS = "000987654321",
                    Name = "Finance Company",
                    Address = "al. Jana Pawła II 19, 00-854 Warsaw",
                    Email = "contact@financecompany.com",
                    PhoneNumber = "987654321"
                }
            }
        );

        modelBuilder.Entity<Software>().HasData(
            new List<Software>
            {
                new Software
                {
                    Id = 1,
                    Name = "Microsoft 365",
                    Description = "A collection of applications and services available from Microsoft servers.",
                    Category = "Business"
                },
                new Software
                {
                    Id = 2,
                    Name = "Adobe Photoshop",
                    Description = "A graphic program intended for creating and processing raster graphics.",
                    Category = "Graphic Design"
                }
            }
        );

        modelBuilder.Entity<SoftwareVersion>().HasData(
            new List<SoftwareVersion>
            {
                new SoftwareVersion
                {
                    Id = 1,
                    Version = 2405m,
                    SoftwareId = 1
                },
                new SoftwareVersion
                {
                    Id = 2,
                    Version = 2406m,
                    SoftwareId = 1
                },
                new SoftwareVersion
                {
                    Id = 3,
                    Version = 25.8m,
                    SoftwareId = 2
                },
                new SoftwareVersion
                {
                    Id = 4,
                    Version = 25.9m,
                    SoftwareId = 2
                }
            }
        );

        modelBuilder.Entity<Discount>().HasData(
            new List<Discount>
            {
                new Discount
                {
                    Id = 1,
                    Name = "Happy June Discount",
                    PercentageValue = 10.5m,
                    StartDate = new DateTime(2024, 06, 01),
                    EndDate = new DateTime(2024, 06, 30),
                    SoftwareId = 1
                },
                new Discount
                {
                    Id = 2,
                    Name = "Graphic Design Week Discount",
                    PercentageValue = 5m,
                    StartDate = new DateTime(2024, 06, 24),
                    EndDate = new DateTime(2024, 06, 28),
                    SoftwareId = 2
                }
            }
        );
    }

}