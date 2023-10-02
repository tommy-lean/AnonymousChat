using Microsoft.EntityFrameworkCore;
using TestProject.Models;

namespace TestProject.Context;

public interface IAppDbContext
{
    
    
    DbSet<User> Users { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}