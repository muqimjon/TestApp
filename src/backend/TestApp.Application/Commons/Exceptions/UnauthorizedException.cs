namespace TestApp.Application.Commons.Exceptions;

using System.Net;

public class UnauthorizedException(string message) : TestAppException(message, HttpStatusCode.Unauthorized);