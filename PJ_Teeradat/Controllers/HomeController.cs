using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PJ_Teeradat.Models;

namespace PJ_Teeradat.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            getsession();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public void getsession()
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            ViewBag.UserType = HttpContext.Session.GetString("UserType");
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            ViewBag.img = HttpContext.Session.GetString("UserImg");
        }
    }
}
