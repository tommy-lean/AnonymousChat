namespace TestProject.Dtos;

public record UserDto(string Login, string Password, string Gender, string Name, string LastName,
    DateTimeOffset DateOfBirth, bool IsAnonymousProfile, bool IsJustChatting);
