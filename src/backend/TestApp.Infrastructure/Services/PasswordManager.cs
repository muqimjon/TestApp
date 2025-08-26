namespace TestApp.Infrastructure.Services;

using TestApp.Application.Commons.Interfaces;

public class PasswordManager : IPasswordManager
{
    public string Hash(string password)
        => BCrypt.Net.BCrypt.HashPassword(password);

    public bool Verify(string hashedPassword, string password)
        => BCrypt.Net.BCrypt.Verify(password, hashedPassword);
}
