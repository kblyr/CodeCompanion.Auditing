using Microsoft.AspNetCore.Http;

namespace CodeCompanion.Auditing
{
    sealed class CurrentUserIdProvider : ICurrentUserIdProvider
    {
        readonly string _claimType;
        readonly IHttpContextAccessor _contextAccessor;

        public CurrentUserIdProvider(IHttpContextAccessor contextAccessor, string claimType)
        {
            _contextAccessor = contextAccessor;
            _claimType = claimType;
        }

        public int? Current
        {
            get
            {
                var context = _contextAccessor.HttpContext;

                if (context is null)
                    return null;

                var claim = context.User.FindFirst(_claimType);

                if (claim is null)
                    return null;

                if (!int.TryParse(claim.Value, out int value))
                    return null;

                return value;
            }
        }
    }

    
}