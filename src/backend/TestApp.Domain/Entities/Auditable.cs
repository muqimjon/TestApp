﻿namespace TestApp.Domain.Entities;

public abstract class Auditable
{
    public long Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}
