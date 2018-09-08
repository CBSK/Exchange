#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using OneTETH.Models;

namespace OneTETH.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model)
        {
            if (ValidateUser(model))
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, model.Username));
                claims.Add(new Claim(ClaimTypes.Email, model.Password));
                var id = new ClaimsIdentity(claims,
                                            DefaultAuthenticationTypes.ApplicationCookie);

                var ctx = Request.GetOwinContext();
                var authenticationManager = ctx.Authentication;
                authenticationManager.SignIn(id);
                return RedirectToAction("Invoice", "EzyMonitor");
            }
            return View(model);

        }

        private bool ValidateUser(LoginModel model)
        {
            if (model.Username.Trim().ToLower() == "tiffatest" && model.Password == "T!ff@")
            {
                return true;
            }
            if (model.Username.Trim().ToLower() == "benjawan" && model.Password == "benjawan!23")
            {
                return true;
            }
            if (model.Username.Trim().ToLower() == "supattra" && model.Password == "supattra!23")
            {
                return true;
            }
            if (model.Username.Trim().ToLower() == "pundasri" && model.Password == "pundasri!23")
            {
                return true;
            }
            if (model.Username.Trim().ToLower() == "supisa" && model.Password == "supisa!23")
            {
                return true;
            }
            if (model.Username.Trim().ToLower() == "chutima" && model.Password == "chutima!23")
            {
                return true;
            }
            if (model.Username.Trim().ToLower() == "ladda" && model.Password == "ladda!23")
            {
                return true;
            }
            if (model.Username.Trim().ToLower() == "worawut" && model.Password == "worawut!23")
            {
                return true;
            }
            if (model.Username.Trim().ToLower() == "kanchana" && model.Password == "kanchana!23")
            {
                return true;
            }
            if (model.Username.Trim().ToLower() == "nutnaree" && model.Password == "nutnaree!23")
            {
                return true;
            }
            if (model.Username.Trim().ToLower() == "suchada" && model.Password == "suchada!23")
            {
                return true;
            }
            if (model.Username.Trim().ToLower() == "kamollak" && model.Password == "kamollak!23")
            {
                return true;
            }
            if (model.Username.Trim().ToLower() == "dnex" && model.Password == "dnex!23")
            {
                return true;
            }

            return false;
        }

        public ActionResult LogOut()
        {
            var ctx = Request.GetOwinContext();
            var authenticationManager = ctx.Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("Login");
        }

    }
}