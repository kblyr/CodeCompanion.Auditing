namespace CodeCompanion.Auditing
{
    public interface ICurrentTimestampProvider
    {
        DateTimeOffset? Current { get; }
    }
}