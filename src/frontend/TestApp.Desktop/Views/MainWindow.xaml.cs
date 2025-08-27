using System.Windows;
using TestApp.ClientService.Services;
using TestApp.Desktop.Views.Pages;

namespace TestApp.Desktop;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        if (AuthStore.Instance is not null)
            MainFrame.Navigate(new LoginPage());
    }
}