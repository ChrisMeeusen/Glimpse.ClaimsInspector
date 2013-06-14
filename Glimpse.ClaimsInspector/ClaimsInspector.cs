using System.Collections.Generic;
using System.Linq;
using Glimpse.AspNet.Extensions;
using Glimpse.Core.Extensibility;
using System.Security.Claims;

namespace Glimpse.ClaimsInspector
{
    public class ClaimsInspector : TabBase
    {
        public override object GetData(ITabContext context)
        {
            var res = new List<string[]> { new[] { "Subject", "Type", "Value", "Value Type", "Issuer", "Original Issuer" } };
            var httpContext = context.GetHttpContext();

            var iPrincipal = (ClaimsPrincipal)httpContext.User;
            var identity = (ClaimsIdentity)iPrincipal.Identity;

            res.AddRange(identity.Claims.Select(c => new[] {  c.Subject==null?string.Empty:c.Subject.ToString(),c.Type, 
                c.Value, c.ValueType, c.Issuer ,c.OriginalIssuer }));

            return res;
        }

        public override string Name
        {
            get { return "Claim Data"; }
        }
    }
}