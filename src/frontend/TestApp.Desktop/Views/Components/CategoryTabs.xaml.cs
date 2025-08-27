namespace TestApp.Desktop.Views.Components;

using System.Windows;
using System.Windows.Controls;
using TestApp.ClientService.Api;
using TestApp.ClientService.Services;

public partial class CategoryTabs : UserControl
{
    private readonly IApiCategories api;
    public static event Action<int> CategorySelected;

    public CategoryTabs()
    {
        InitializeComponent();

        api = ApiServiceFactory.Create<IApiCategories>();

        Loaded += CategoryTabs_Loaded;
    }

    private async void CategoryTabs_Loaded(object sender, RoutedEventArgs e)
    {
        await LoadCategories();
    }

    private async Task LoadCategories()
    {
        var allBtn = CreateCategoryButton(0, "Hammasi");
        CategoriesPanel.Children.Add(allBtn);

        var response = await api.GetAllCategoriesAsync();
        if (response.StatusCode != 200)
            return;

        var categories = response.Data;

        foreach (var category in categories)
        {
            if (category.Tests.Count == 0)
                continue;
            var btn = CreateCategoryButton(category.Id, category.Name);
            CategoriesPanel.Children.Add(btn);
        }
    }

    private Button CreateCategoryButton(int id, string name)
    {
        var btn = new Button
        {
            Content = name,
            Tag = id,
            Margin = new Thickness(5),
            Padding = new Thickness(10, 5, 10, 5),
            Background = System.Windows.Media.Brushes.LightGray,
            BorderThickness = new Thickness(0)
        };

        btn.Click += CategoryButton_Click;
        return btn;
    }

    private void CategoryButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button btn)
        {
            int categoryId = (int)btn.Tag;
            CategorySelected?.Invoke(categoryId);
        }
    }
}
