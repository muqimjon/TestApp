namespace TestApp.Infrastructure.Services;

using TestApp.Application.Commons.Interfaces;

public class PasswordManager : IPasswordManager
{
    public string Hash(string password)
        => BCrypt.Net.BCrypt.HashPassword(password);

    public bool Verify(string password, string hashedPassword)
        => BCrypt.Net.BCrypt.Verify(password, hashedPassword);
}

