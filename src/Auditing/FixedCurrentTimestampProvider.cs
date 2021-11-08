namespace CodeCompanion.Auditing
{
    sealed class FixedCurrentTimestampProvider : ICurrentTimestampProvider
    {
        public DateTimeOffset? Current { get; }

        public FixedCurrentTimestampProvider(DateTimeOffset? current)
        {
            Current = current;
        }
    }
}