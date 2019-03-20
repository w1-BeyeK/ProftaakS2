using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webapp.Interfaces;
using Webapp.Models;
using Webapp.Models.Exceptions;
using Webapp.Repository;

namespace Webapp.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginRepository repo;

        public LoginController(IContext context)
        {
            repo = new LoginRepository(context);
        }
        
        public IActionResult Index(string msg = null)
        {
            ViewData["errorMsg"] = msg;
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            try
            {
                LoginResult result = repo.Login(username, password);

                HttpContext.Session.SetString("uid", result.Id.ToString());
                HttpContext.Session.SetString("uname", result.Name);
                HttpContext.Session.SetString("loginType", result.Type);

                return RedirectToAction("about", "home");
            }
            catch(UserNotFoundException e)
            {
                return RedirectToAction("index", new { msg = e.Message });
            }
            catch(Exception)
            {
                return RedirectToAction("index", new { msg = "Something went wrong!" });
            }
        }
    }
}