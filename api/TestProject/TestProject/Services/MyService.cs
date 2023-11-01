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
         var existUser = await _appDbContext.Users.Where(q => q.Login == userInfo.Login)
             .FirstOrDefaultAsync(cancellationToken);
         if (existUser != null)
         {
             throw new ArgumentException($"Пользователь с именем {userInfo.Login} уже существует");
         }
         var user = new User(Guid.NewGuid(), userInfo.Login, userInfo.Password, userInfo.Gender, userInfo.Name, 
             userInfo.LastName, DateTime.Now, 
             userInfo.IsAnonymousProfile, userInfo.IsJustChatting);
         _appDbContext.Users.Add(user);
         await _appDbContext.SaveChangesAsync(cancellationToken);

         return user.Id;
     }

     public async Task<bool> AuthenticationUser(UserDto userDtoInfo, CancellationToken cancellationToken)
     {
         
         var user =  await _appDbContext.Users.Where(q => q.Login == userDtoInfo.Login).FirstOrDefaultAsync(cancellationToken);
         if (user == null)
         {
             return false;
         }
         return user.Login == userDtoInfo.Login && user.Password == userDtoInfo.Password;
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
