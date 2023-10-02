using TestProject.Context;
using TestProject.Dtos;
using TestProject.Models;

namespace TestProject.Services;

public class MyService : IMyService
{
    private readonly IAppDbContext _appDbContext;
    
     public MyService(IAppDbContext appDbContext)
     {
         _appDbContext = appDbContext;
     }

     public async Task<Guid> CreateUser(UserDto userInfo, CancellationToken cancellationToken)
     {
         var user = new User(Guid.NewGuid(), userInfo.Name, userInfo.Password);
         _appDbContext.Users.Add(user);
         await _appDbContext.SaveChangesAsync(cancellationToken);

         return user.Id;
     }
          
}