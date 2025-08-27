namespace TestApp.ClientService.Models;

public class UserDto
{
    public long Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
}