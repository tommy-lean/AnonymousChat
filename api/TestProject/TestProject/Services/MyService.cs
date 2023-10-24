using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using TestProject.Context;
using TestProject.Dtos;
using TestProject.Models;

namespace TestProject.Services;

public class MyService : IMyService
{
    // ----------
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

     public async Task<bool> AuthenticationUser(UserDto userDtoInfo, CancellationToken cancellationToken, User userServerInfo)
     {
         
         var user =  await _appDbContext.Users.Where(q => q.FirstName == userDtoInfo.Name).SingleOrDefaultAsync(cancellationToken);
         if (user.FirstName == userDtoInfo.Name && user.Password == userDtoInfo.Password)
         {
             return await Task.FromResult(true);
         }
         else
         {
             return await Task.FromResult(false);
         }

     }
          
}
         // if (userServerInfo.FirstName == userDtoInfo.Name && userServerInfo.Password == userDtoInfo.Password)
         // {
         //    return true;
         // }
         // else
         // {
         //     return false;
         // }
