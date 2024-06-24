using Microsoft.EntityFrameworkCore;
using RevenueRecognitionSystem.Models;

namespace RevenueRecognitionSystem.Contexts;

public class DatabaseContext : DbContext
{
    public DbSet<Person> People { get; set; }
    public DbSet<Company> Companies { get; set; }
    
    protected DatabaseContext()
    {
        
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Person>().HasData(
            new List<Person>
            {
                new Person
                {
                    PESEL = "12345678901",
                    FirstName = "John",
                    LastName = "Doe",
                    Address = "Koszykowa 86, 02-008 Warsaw",
                    Email = "john.doe@gmail.com",
                    PhoneNumber = "123456789"
                },
                new Person
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

        modelBuilder.Entity<Company>().HasData(
            new List<Company>
            {
                new Company
                {
                    KRS = "000123456789",
                    Name = "Tech Company",
                    Address = "rondo Daszyńskiego 2, 00-843 Warsaw",
                    Email = "contact@techcompany.com",
                    PhoneNumber = "123456789"
                },
                new Company
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