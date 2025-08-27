namespace TestApp.ClientService.Models;

public class QuestionUploadDto
{
    public object Text { get; set; }
    public List<AnswerOptionUploadDto> Options { get; set; }
}