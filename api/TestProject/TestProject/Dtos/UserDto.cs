namespace TestProject.Dtos;

// public record UserDto(string Login, string Password, string? Gender, string Name, string? LastName,
//     DateTimeOffset? DateOfBirth, bool IsAnonymousProfile, bool IsJustChatting);

public record UserDto
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string? Gender { get; set; }
    public string Name { get; set; }
    public string? LastName { get; set; }
    public DateTimeOffset? DateOfBirth { get; set; }
    public bool IsAnonymousProfile { get; set; }
    public bool IsJustChatting { get; set; }
}