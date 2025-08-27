namespace TestApp.ClientService.Models;

public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<TestDto> Tests { get; set; } = default!;
}