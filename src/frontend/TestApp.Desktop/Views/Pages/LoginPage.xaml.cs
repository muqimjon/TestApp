namespace TestApp.Desktop.Views.Pages;

using System.Windows;
using System.Windows.Controls;
using TestApp.ClientService.Services;

public partial class LoginPage : Page
{
    private AuthService service = new();
    public LoginPage()
    {
        InitializeComponent();
    }

    private void RegisterButton_Click(object sender, RoutedEventArgs e)
    {
        if (Window.GetWindow(this) is MainWindow mainWindow)
        {
            mainWindow.MainFrame.Navigate(new RegisterPage());
        }
    }

    private async void SubmitButton_Click(object sender, RoutedEventArgs e)
    {
        var result = await service.LoginAsync(tbUsername.Text, pbPassword.Password);

        if (result && Window.GetWindow(this) is MainWindow mainWindow)
            mainWindow.MainFrame.Navigate(new HomePage());
        else
            MessageBox.Show("xatolik");
    }
}
