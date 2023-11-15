using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using TestProject.Context;
using TestProject.Dtos;
using TestProject.Models;
using TestProject.Security;

namespace TestProject.Services;

public class MyService : IMyService
{
    // ----------
    private readonly IAppDbContext _appDbContext;
    private readonly IPasswordHasher _passwordHash;
    
     public MyService(IAppDbContext appDbContext, IPasswordHasher passwordHash)
     {
         _appDbContext = appDbContext;
         _passwordHash = passwordHash;
     }

     public async Task<Guid> CreateUser(UserDto userInfo, CancellationToken cancellationToken)
     {
         var existUser = await _appDbContext.Users.Where(q => q.Login == userInfo.Login)
             .FirstOrDefaultAsync(cancellationToken);
         if (existUser != null)
         {
             throw new ArgumentException($"Пользователь с именем {userInfo.Login} уже существует");
         }

         var passwordHash = _passwordHash.Hash(userInfo.Password);
         
         var user = new User(Guid.NewGuid(), userInfo.Login, passwordHash, userInfo.Name){
             Gender = userInfo.Gender, LastName = userInfo.LastName, DateOfBirth = userInfo.DateOfBirth, 
             IsAnonymousProfile = userInfo.IsAnonymousProfile, IsJustChatting = userInfo.IsJustChatting
             };
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

         var verificationPassword = _passwordHash.Verify(user.Password, userDtoInfo.Password);
         
         return user.Login == userDtoInfo.Login && verificationPassword;
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
