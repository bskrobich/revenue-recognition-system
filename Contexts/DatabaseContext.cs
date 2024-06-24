using Microsoft.EntityFrameworkCore;
using RevenueRecognitionSystem.Models;
using RevenueRecognitionSystem.Models.Clients;

namespace RevenueRecognitionSystem.Contexts;

public class DatabaseContext : DbContext
{
    public DbSet<PersonClient> People { get; set; }
    public DbSet<CompanyClient> Companies { get; set; }
    
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
                    PESEL = "12345678901",
                    FirstName = "John",
                    LastName = "Doe",
                    Address = "Koszykowa 86, 02-008 Warsaw",
                    Email = "john.doe@gmail.com",
                    PhoneNumber = "123456789"
                },
                new PersonClient
                {
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
                    KRS = "000123456789",
                    Name = "Tech Company",
                    Address = "rondo Daszyńskiego 2, 00-843 Warsaw",
                    Email = "contact@techcompany.com",
                    PhoneNumber = "123456789"
                },
                new CompanyClient
                {
                    KRS = "000987654321",
                    Name = "Finance Company",
                    Address = "al. Jana Pawła II 19, 00-854 Warsaw",
                    Email = "contact@financecompany.com",
                    PhoneNumber = "987654321"
                }
            }
        );
    }
    
}