using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webapp.Interfaces;
using Webapp.Models;
using Webapp.Models.Data;
using Webapp.Repository;

namespace Webapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly PatientRepository repo;

        public HomeController(IContext context)
        {
            repo = new PatientRepository(context);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            ViewData["uname"] = HttpContext.Session.GetString("uname");
            ViewData["loginType"] = HttpContext.Session.GetString("loginType");

            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            try
            {
                Patient patient = repo.LoginPatient(username, password);
                HttpContext.Session.SetString("user", patient.Name);
                HttpContext.Session.SetString("loginType", "patient");
                return RedirectToAction("about");
            }
            catch(Exception e)
            {
                return RedirectToAction("index");
            }

            //string s1 = username;//
            //string s2 = password;//
            //if(username== "Admin" && password == "Admin")
            //{
            //    ViewData["succes"] = "Login Succes";
            //    ViewData["username"] = username;
            //    ViewData["password"] = password;
            //}
            //else
            //{
            //    ViewData["Message"] = "Login gefaald!!!!!!";
            //}
            //return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
