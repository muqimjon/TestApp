namespace TestApp.Application.Features.Questions.Commands;

using AutoMapper;
using MediatR;
using TestApp.Application.Commons.Interfaces;
using TestApp.Application.Features.Questions.DTOs;
using TestApp.Domain.Entities;

public record AddQuestionCommand(
    int TestId,
    string Text,
    List<AnswerOptionForCreateDto> Options)
    : IRequest<QuestionDto>;

public class AddQuestionCommandHandler(
    IAppDbContext db,
    IMapper mapper)
    : IRequestHandler<AddQuestionCommand, QuestionDto>
{
    public async Task<QuestionDto> Handle(
        AddQuestionCommand request,
        CancellationToken cancellationToken)
    {
        var question = new Question
        {
            TestId = request.TestId,
            Text = request.Text
        };

        foreach (var optDto in request.Options)
            question.Options.Add(
                new AnswerOption
                {
                    Text = optDto.Text,
                    IsCorrect = optDto.IsCorrect,
                    QuestionId = question.Id,
                    CreatedAt = DateTimeOffset.UtcNow
                });

        db.Questions.Add(question);
        await db.SaveAsync(cancellationToken);

        return mapper.Map<QuestionDto>(question);
    }
}
