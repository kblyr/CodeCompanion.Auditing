namespace CodeCompanion.Auditing
{
    sealed class CurrentFootprintProvider : ICurrentFootprintProvider
    {
        readonly object _lockObj = new();
        readonly ICurrentUserIdProvider _userIdProvider;
        readonly ICurrentTimestampProvider _timestampProvider;

        public CurrentFootprintProvider(ICurrentUserIdProvider userIdProvider, ICurrentTimestampProvider timestampProvider)
        {
            _userIdProvider = userIdProvider;
            _timestampProvider = timestampProvider;
        }

        Footprint? _current;
        public Footprint Current
        {
            get
            {
                lock (_lockObj)
                {
                    if (_current is not null)
                        return _current;

                    _current = new() 
                    {
                        UserId = _userIdProvider.Current,
                        Timestamp = _timestampProvider.Current
                    };

                    return _current;
                }
            }
        }
    }
}