namespace TestApp.WebApi.Models;

public class Response
{
    public string Message { get; set; } = "Success";
    public int Status { get; set; } = StatusCodes.Status200OK;
    public object? Data { get; set; }
}
