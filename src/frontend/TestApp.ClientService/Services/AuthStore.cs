namespace TestApp.ClientService.Services;

using System.ComponentModel;
using System.Runtime.CompilerServices;

public class AuthStore : INotifyPropertyChanged
{
    private static string token = string.Empty;
    private static string fullName = string.Empty;
    private static long userId;

    public string Token
    {
        get => token;
        private set
        {
            token = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsAuthenticated));
        }
    }

    public string FullName
    {
        get => fullName;
        private set
        {
            fullName = value;
            OnPropertyChanged();
        }
    }

    public long UserId
    {
        get => userId;
        private set
        {
            userId = value;
            OnPropertyChanged();
        }
    }

    public bool IsAuthenticated => !string.IsNullOrEmpty(Token);

    public void SetAuth(string token, string fullName, long userId)
    {
        Token = token;
        FullName = fullName;
        UserId = userId;
    }

    public void Logout()
    {
        Token = string.Empty;
        FullName = string.Empty;
        UserId = 0;
    }

    public static readonly AuthStore Instance = new();

    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string name = null!)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    #endregion
}
