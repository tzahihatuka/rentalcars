using _01_BOL;
using _02_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace _03_UIL.Filter
{
    public class AuthenticationFilter : Attribute, IAuthenticationFilter
    {
        public bool AllowMultiple { get { return false; } }

        Task IAuthenticationFilter.AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var authHead = context.Request.Headers.Authorization;

            if(authHead!= null)
            {
                BOLUserInfo user = ValidateUserInput.GetUser(authHead.Scheme, authHead.Parameter);

                if (user != null)
                {
                    var claims = new List<Claim>() { new Claim(ClaimTypes.Name,user.UserName),
                                                     new Claim(ClaimTypes.Role, user.GetUserRole()) };
                    var id = new ClaimsIdentity(claims, "Token");
                    context.Principal = new ClaimsPrincipal(new[] { id });
                }
                else
                {
                    context.ErrorResult = new UnauthorizedResult(
                        new AuthenticationHeaderValue[0], context.Request);
                }
            }
            return Task.FromResult(0);
        }

        Task IAuthenticationFilter.ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}