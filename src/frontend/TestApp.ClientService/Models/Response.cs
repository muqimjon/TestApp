namespace TestApp.ClientService.Models;

public class Response<T>
{
    public T? Data { get; set; }
    public string Message { get; set; } = string.Empty;
    public int StatusCode { get; set; }
}