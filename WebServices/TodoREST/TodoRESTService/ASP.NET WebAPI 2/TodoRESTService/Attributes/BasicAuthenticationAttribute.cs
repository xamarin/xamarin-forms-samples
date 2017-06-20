using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using TodoRESTService.Extensions;

namespace TodoRESTService.Attributes
{
    public class BasicAuthenticationAttribute : AuthorizeAttribute
    {
        public bool RequireSsl { get; set; }

        public BasicAuthenticationAttribute()
        {
            this.RequireSsl = true;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext == null)
            {
                throw new ArgumentNullException("actionContext");
            }

            var isAuthenticated = this.Authorize(actionContext);
            if (!isAuthenticated)
            {
                SendUnauthorizedResponse(actionContext);
            }
        }
        
        private BasicAuthenticationIdentity ParseAuthorizationHeader(HttpActionContext actionContext)
        {
            string authHeader = null;
            var auth = actionContext.Request.Headers.Authorization;
            if (auth != null && auth.Scheme == "Basic")
            {
                authHeader = auth.Parameter;
            }

            if (string.IsNullOrWhiteSpace(authHeader))
            {
                return null;
            }

            if (authHeader.IsBase64Encoded())
            {
                authHeader = Encoding.Default.GetString(Convert.FromBase64String(authHeader));
            }
            else
            {
                return null;
            }
 
            int index = authHeader.IndexOf(':');
            if (index < 0)
            {
                return null;
            }

            string username = authHeader.Substring(0, index);
            string password = authHeader.Substring(index + 1);

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            return new BasicAuthenticationIdentity(username, password);
        }

        private bool Authorize(HttpActionContext actionContext)
        {
            var httpContext = HttpContext.Current;

            if (httpContext.Request.IsAuthenticated)
            {
                return true;
            }

            if (this.RequireSsl && !httpContext.Request.IsSecureConnection && !httpContext.Request.IsLocal)
            {
                return false;
            }

            if (!httpContext.Request.Headers.AllKeys.Contains("Authorization"))
            {
                return false;
            }


            var identity = ParseAuthorizationHeader(actionContext);
            if (identity == null)
            {
                return false;
            }

            var username = ConfigurationManager.AppSettings["Username"];
            var password = ConfigurationManager.AppSettings["Password"];

            bool isAuthorized = false;
            if (username == identity.Name && password == identity.Password)
            {
                isAuthorized = true;
            }

            return isAuthorized;
        }

        private void SendUnauthorizedResponse(HttpActionContext actionContext)
        {
            var host = actionContext.Request.RequestUri.DnsSafeHost;
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            actionContext.Response.Headers.Add("WWW-Authenticate", "Basic");
        }
    }
}
