namespace CodeCompanion.Auditing
{
    public interface ICurrentUserIdProvider
    {
        int? Current { get; }
    }
}