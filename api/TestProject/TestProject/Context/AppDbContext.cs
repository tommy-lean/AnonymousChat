using Microsoft.EntityFrameworkCore;
using TestProject.Models;

namespace TestProject.Context;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
        
    }

    public DbSet<User> Users => Set<User>();
}