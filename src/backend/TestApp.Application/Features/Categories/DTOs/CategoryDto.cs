namespace TestApp.Application.Features.Categories.DTOs;

using TestApp.Domain.Entities;

public record CategoryDto(long Id, string Name, List<Test> Tests);