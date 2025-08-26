namespace TestApp.Application.Commons;

using AutoMapper;
using TestApp.Application.Features.Authentication.DTOs;
using TestApp.Application.Features.Categories.DTOs;
using TestApp.Application.Features.Questions.DTOs;
using TestApp.Application.Features.Tests.DTOs;
using TestApp.Application.Features.TestSessions.DTOs;
using TestApp.Domain.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<Test, TestDto>();
        CreateMap<Question, QuestionDto>();
        CreateMap<Category, CategoryDto>();
        CreateMap<TestSession, TestSessionDto>();
    }
}
