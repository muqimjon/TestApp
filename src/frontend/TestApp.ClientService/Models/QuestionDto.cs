namespace TestApp.ClientService.Models;

public class QuestionDto
{
    public long Id { get; set; }
    public long TestId { get; set; }
    public string Text { get; set; } = string.Empty;
    public List<AnswerOptionDto> Options { get; set; } = [];
}