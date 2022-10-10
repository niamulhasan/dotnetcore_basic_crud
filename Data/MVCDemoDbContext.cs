using Microsoft.EntityFrameworkCore;
using MVCcrud.Models.Domain;

namespace MVCcrud.Data;

public class MVCDemoDbContext : DbContext
{
    
    public MVCDemoDbContext(DbContextOptions<MVCDemoDbContext> options) : base(options)
    {
    }
    
    public DbSet<Employee> Employees { get; set; }

}