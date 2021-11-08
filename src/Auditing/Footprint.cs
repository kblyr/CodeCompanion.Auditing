namespace CodeCompanion.Auditing
{
    public record Footprint
    {
        public int? UserId { get; init; }
        public DateTimeOffset? Timestamp { get; init; }
    }
}