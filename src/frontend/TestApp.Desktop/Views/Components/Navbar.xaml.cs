namespace TestApp.Desktop.Views.Components;

using ClosedXML.Excel;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using TestApp.ClientService.Api;
using TestApp.ClientService.Models;
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
        this.Loaded += Navbar_Loaded;
    }

    private async void Navbar_Loaded(object sender, RoutedEventArgs e)
    {
        var categories = await api.GetAllCategoriesAsync();

        if (categories.StatusCode != 200)
            return;
        CategoryCombo.ItemsSource = categories.Data;
        CategoryCombo.DisplayMemberPath = "Name";
        CategoryCombo.SelectedValuePath = "Id";
    }

    private void ExitButton_Click(object sender, RoutedEventArgs e)
    {
        if (Window.GetWindow(this) is MainWindow mainWindow)
        {
            mainWindow.MainFrame.Navigate(new LoginPage());
        }
    }

    private async void AddButton_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new()
        {
            Filter = "Excel Files|*.xlsx;*.xls",
        };


        if (openFileDialog.ShowDialog() == true)
        {
            await api.FindOrCreate(CategoryCombo.SelectedItem.ToString()!);

            string filePath = openFileDialog.FileName;

            ExcelReader.ReadExcel(filePath, 1);
        }
    }
}

public static class ExcelReader
{
    public static TestUploadDto ReadExcel(string filePath, long categoryId)
    {
        using var workbook = new XLWorkbook(filePath);
        var worksheet = workbook.Worksheets.First();

        var test = new TestUploadDto
        {
            Title = Path.GetFileNameWithoutExtension(filePath),
            CategoryId = categoryId,
            Questions = []
        };

        foreach (var row in worksheet.RowsUsed())
        {
            var question = new QuestionUploadDto
            {
                Text = row.Cell(1).GetString(),
                Options = []
            };

            for (int i = 2; i <= 5; i++)
            {
                question.Options.Add(new AnswerOptionUploadDto
                {
                    Text = row.Cell(i).GetString(),
                    IsCorrect = (i == 2)
                });
            }

            test.Questions.Add(question);
        }

        return test;
    }
}
