namespace TestApp.Desktop.Views.Components;

using Microsoft.Win32;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TestApp.ClientService.Api;
using TestApp.ClientService.Services;
using TestApp.Desktop.Views.Pages;

public partial class Navbar : UserControl
{
    private IApiCategories api;
    public Navbar()
    {
        InitializeComponent();
        api = ApiServiceFactory.Create<IApiCategories>();
        DataContext = AuthStore.Instance;
    }


    private void ExitButton_Click(object sender, RoutedEventArgs e)
    {

        if (Window.GetWindow(this) is MainWindow mainWindow)
        {
            mainWindow.MainFrame.Navigate(new LoginPage());
        }
    }

    private async Task AddButton_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new()
        {
            Filter = "Excel Files|*.xlsx;*.xls",
        };


        if (openFileDialog.ShowDialog() == true)
        {
            await api.GetAllCategoriesAsync();

            string filePath = openFileDialog.FileName;

            MessageBox.Show($"Tanlangan fayl: {filePath}");
        }
    }
}
