using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webapp.Models.Data;

namespace Webapp.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
<<<<<<< HEAD
            List<Doctor> items = new List<Doctor>()
            {
               
            };
            return View(items);
=======
            return View();
>>>>>>> 7d367c4ea3e2a561b5b78310aa8fec241238d53d
        }
    }
}