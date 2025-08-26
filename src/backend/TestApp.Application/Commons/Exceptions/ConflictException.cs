namespace TestApp.Application.Commons.Exceptions;

using System.Net;

public class ConflictException(string message) : TestAppException(message, HttpStatusCode.Conflict);