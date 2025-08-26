namespace TestApp.Domain.Entities;

public class TestSession : Auditable
{
    public long UserId { get; set; }
    public long TestId { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }

    public User User { get; set; } = null!;
    public Test Test { get; set; } = null!;
    public ICollection<SessionQuestion> Questions { get; set; } = [];
}
