namespace TestApp.Application.Commons.Exceptions;

using System.Net;

public class NotFoundException(string message) : TestAppException(message, HttpStatusCode.NotFound);