namespace TestApp.Application.Commons.Interfaces;

public interface IPasswordManager
{
    string Hash(string password);
    bool Verify(string hashedPassword, string password);
}