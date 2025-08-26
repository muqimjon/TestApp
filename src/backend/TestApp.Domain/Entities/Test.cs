namespace TestApp.Domain.Entities;

public class Test : Auditable
{
    public string Title { get; set; } = string.Empty;
    public ICollection<Question> Questions { get; set; } = [];
}
