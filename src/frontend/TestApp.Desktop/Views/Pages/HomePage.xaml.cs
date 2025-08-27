namespace TestApp.Desktop.Views.Pages;

using System.Windows.Controls;
using TestApp.ClientService.Api;
using TestApp.ClientService.Services;
using TestApp.Desktop.Views.Components;

public partial class HomePage : Page
{
    private readonly IApiTests api;

    public HomePage()
    {
        InitializeComponent();
        api = ApiServiceFactory.Create<IApiTests>();

        Loaded += HomePage_Loaded;
    }

    private async void HomePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
        CategoryTabs.CategorySelected += OnCategorySelected;

        var allTests = await api.GetAllTests();
        if (allTests.StatusCode != 200)
            return;
        TestsList.ItemsSource = allTests.Data;
    }

    private async void OnCategorySelected(int categoryId)
    {
        if (categoryId == 0)
        {
            var all = await api.GetAllTests();
            TestsList.ItemsSource = all.Data;
        }
        else
        {
            var tests = await api.GetTestsByCategoryId(categoryId);
            if (tests.StatusCode != 200)
                return;

            TestsList.ItemsSource = tests.Data;
        }
    }
}
