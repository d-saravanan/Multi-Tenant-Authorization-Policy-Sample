using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace MT.Framework.Core.Authorization
{
    public static class ClaimsIdentityExtensions
    {
        public static T GetValue<T>(this IIdentity identity, string claimType)
        {
            if (!identity.IsAuthenticated) throw new UnauthorizedAccessException("The passed identity is not yet authenticated.");

            // don't pass empty claimtype to get default values...
            if (string.IsNullOrWhiteSpace(claimType)) return default(T);

            var claimValue = ((ClaimsIdentity)identity).FindFirst(claimType)?.Value;

            return ParseClaimValue<T>(claimValue);
        }

        public static T GetValue<T>(this IEnumerable<Claim> claims, string claimType)
        {
            // don't pass empty collection of claims or claimtype to get default values...
            if (!claims.Any() || string.IsNullOrWhiteSpace(claimType)) return default(T);

            //Chooses only the first match, assuming there can be only 1 unique claim with a values, makes sense?...
            var claimValue = claims.FirstOrDefault(c => c.Type.Equals(claimType))?.Value;

            return ParseClaimValue<T>(claimValue);
        }

        private static T ParseClaimValue<T>(string claimValue)
        {
            if (string.IsNullOrWhiteSpace(claimValue)) return default(T); // claim is available, but has no value, hence defaulting to default values.

            var targetValue = (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromInvariantString(claimValue);

            //TODO: Gross: Review this
            if (null == targetValue) return default(T); // Type conversion failed and returned null, returning the default value. 

            return (T)targetValue;
        }
    }
}
