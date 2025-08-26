namespace TestApp.Domain.Entities;

public class TestSession : Auditable
{
    public long UserId { get; set; }
    public long TestId { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public ICollection<SessionQuestion> Questions { get; set; } = [];
}
