namespace TestApp.Domain.Entities;

public class Question : Auditable
{
    public long TestId { get; set; }
    public string Text { get; set; } = string.Empty;

    public Test Test { get; set; } = null!;
    public ICollection<AnswerOption> Options { get; set; } = [];
}
