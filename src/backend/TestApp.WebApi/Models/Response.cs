namespace TestApp.WebApi.Models;

public class Response
{
    public string Message { get; set; } = "Success";
    public int StatusCode { get; set; } = StatusCodes.Status200OK;
    public object? Data { get; set; }
}
