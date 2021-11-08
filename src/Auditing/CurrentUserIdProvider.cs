namespace CodeCompanion.Auditing
{
    sealed class CurrentUserIdProvider : ICurrentUserIdProvider
    {
        public int? Current { get; }

        public CurrentUserIdProvider(int? current)
        {
            Current = current;
        }
    }
}