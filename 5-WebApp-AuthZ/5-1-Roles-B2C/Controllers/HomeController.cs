﻿using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp_OpenIDConnect_DotNet.Infrastructure;
using WebApp_OpenIDConnect_DotNet.Models;

namespace WebApp_OpenIDConnect_DotNet.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            ViewData["User"] = HttpContext.User;
            return View();
        }

        [Authorize(AuthorizationPolicies.AssignmentToAdminRoleRequired)]
        public IActionResult Admins()
        {
            return View();
        }

        [Authorize(AuthorizationPolicies.AssignmentToUserRoleRequired)]
        public IActionResult Users()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}