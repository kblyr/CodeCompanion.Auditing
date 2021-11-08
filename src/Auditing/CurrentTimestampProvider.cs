namespace CodeCompanion.Auditing
{
    sealed class CurrentTimestampProvider : ICurrentTimestampProvider
    {
        public DateTimeOffset? Current => DateTimeOffset.Now;
    }
}