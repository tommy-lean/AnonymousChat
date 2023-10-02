using TestProject.Dtos;

namespace TestProject.Services;

public interface IMyService
{
    public Task<Guid> CreateUser(UserDto userInfo, CancellationToken cancellationToken);
}