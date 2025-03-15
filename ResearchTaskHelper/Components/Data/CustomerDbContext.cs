using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
public class CustomerDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    public CustomerDbContext(DbContextOptions opt)
: base(opt)
    {


    }
    public void Seed()
    {
        Customers.Add(new Customer(){
            BDay=DateTime.FromFileTime(new Random().Next()),
            LastName=Guid.NewGuid().ToString(),
            FirstName=Guid.NewGuid().ToString(),
        });
        SaveChanges();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

       
    
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        Seed();
    }
}