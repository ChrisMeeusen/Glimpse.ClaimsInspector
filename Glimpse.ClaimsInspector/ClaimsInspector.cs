using System.Collections.Generic;
using System.Linq;
using Glimpse.AspNet.Extensions;
using Glimpse.Core.Extensibility;
using Microsoft.IdentityModel.Claims;

namespace Glimpse.ClaimsInspector
{
    public class ClaimsInspector : TabBase
    {
        public override object GetData(ITabContext context)
        {
            var res = new List<string[]> { new[] { "Subject", "Type", "Value", "Value Type", "Issuer", "Original Issuer" } };
            var httpContext = context.GetHttpContext();

            var iPrincipal = (IClaimsPrincipal)httpContext.User;
            var identity = (IClaimsIdentity)iPrincipal.Identity;

            res.AddRange(identity.Claims.Select(c => new[] {  c.Subject==null?string.Empty:c.Subject.ToString(),c.ClaimType, 
                c.Value, c.ValueType, c.Issuer ,c.OriginalIssuer }));

            return res;
        }

        public override string Name
        {
            get { return "Claim Data"; }
        }
    }
}