namespace TestApp.ClientService.Models;

public class TestDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public List<QuestionDto> Questions { get; set; } = [];
}