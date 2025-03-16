using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
public class CustomerDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<ProfilePicture> ProfilePicture{get;set;}

    public CustomerDbContext(DbContextOptions opt)
: base(opt)
    {


    }
    public Customer CreateRandom()
    {
        Random rnd=new Random();
        int year=rnd.Next(1900,2018);
        int month=rnd.Next(1,13);
        int day=rnd.Next(1,28);
        return new Customer(
            null,
            Guid.NewGuid().ToString(),
           Guid.NewGuid().ToString(),
         new DateTime(year,month,day)

        );
    }
    public void Seed()
    {
        Customers.Add(CreateRandom());
        SaveChanges();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

       
    
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}