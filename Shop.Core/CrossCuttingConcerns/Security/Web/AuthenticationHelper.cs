﻿using System;
using System.Text;
using System.Web;
using System.Web.Security;

namespace Shop.Core.CrossCuttingConcerns.Security.Web
{
    public static class AuthenticationHelper
    {
        /// <summary>
        /// Encrypts the parameters and adds them to the cookie.
        /// </summary>
        public static void CreateAuthCookie(int id, string username, string fullname, string[] roles, DateTime expires, bool rememberMe)
        {
            var authTicket = new FormsAuthenticationTicket(1, username, DateTime.Now, expires, rememberMe, CreateAuthTags(id, fullname, roles), FormsAuthentication.FormsCookiePath);
            var encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket) { Expires = expires });
        }

        /// <summary>
        /// Converts the data to be added to cookies into a specific format.
        /// </summary>
        private static string CreateAuthTags(int id, string fullname, string[] roles)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(fullname);
            stringBuilder.Append("|");
            stringBuilder.Append(id);
            stringBuilder.Append("|");
            stringBuilder.Append(string.Join(",", roles));
            stringBuilder.Append("|");

            return stringBuilder.ToString();
        }
    }
}
