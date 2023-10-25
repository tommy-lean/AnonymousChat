using TestProject.Dtos;
using TestProject.Models;

namespace TestProject.Services;

public interface IMyService
{
    public Task<Guid> CreateUser(UserDto userInfo, CancellationToken cancellationToken);

    public Task<bool> AuthenticationUser(UserDto userInfo, CancellationToken cancellationToken);
}