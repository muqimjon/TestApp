
using TestApp.ClientService.Models;

namespace TestApp.Desktop.Views.Components;

public class TestUploadDto
{
    public object Title { get; set; }
    public long CategoryId { get; set; }
    public List<QuestionUploadDto> Questions { get; set; }
}