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
         var existUser = await _appDbContext.Users.Where(q => q.FirstName == userInfo.Name)
             .FirstOrDefaultAsync(cancellationToken);
         if (existUser != null)
         {
             throw new ArgumentException($"Пользователь с именем {userInfo.Name}");
         }
         var user = new User(Guid.NewGuid(), userInfo.Name, userInfo.Password);
         _appDbContext.Users.Add(user);
         await _appDbContext.SaveChangesAsync(cancellationToken);

         return user.Id;
     }

     public async Task<bool> AuthenticationUser(UserDto userDtoInfo, CancellationToken cancellationToken)
     {
         
         var user =  await _appDbContext.Users.Where(q => q.FirstName == userDtoInfo.Name).FirstOrDefaultAsync(cancellationToken);
         if (user == null)
         {
             return false;
         }
         return user.FirstName == userDtoInfo.Name && user.Password == userDtoInfo.Password;
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
