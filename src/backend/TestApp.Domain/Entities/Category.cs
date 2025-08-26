namespace TestApp.Domain.Entities;

public class Category : Auditable
{
    public string Name { get; set; } = null!;
    public ICollection<Test> Tests { get; set; } = [];
}
