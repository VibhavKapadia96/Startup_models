using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Startup_API.Middleware
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            string authHeader = context.Request.Headers["admin"];
            if (authHeader != null && authHeader == "admin")
            {
                    await _next.Invoke(context);
            }
            else
            {
                // no authorization header
                context.Response.StatusCode = 401; //Unauthorized
                return;
            }



            //string authHeader = context.Request.Headers["Authorization"];
            //if (authHeader != null && authHeader.StartsWith("Basic"))
            //{
            //    //Extract credentials
            //    string encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
            //    Encoding encoding = Encoding.GetEncoding("iso-8859-1");
            //    string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));

            //    int seperatorIndex = usernamePassword.IndexOf(':');

            //    var username = usernamePassword.Substring(0, seperatorIndex);
            //    var password = usernamePassword.Substring(seperatorIndex + 1);

            //    if (username == "admin" && password == "admin")
            //    {
            //        await _next.Invoke(context);
            //    }
            //    else
            //    {
            //        context.Response.StatusCode = 401; //Unauthorized
            //        return;
            //    }
            //}
            //else
            //{
            //    // no authorization header
            //    context.Response.StatusCode = 401; //Unauthorized
            //    return;
            //}

        }
    }
}
