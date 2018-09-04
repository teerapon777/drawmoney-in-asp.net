using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace PJ_Teeradat.Controllers
{
    public class UserController : Controller
    {

        private readonly Models.DrawmoneyContext db;
        public UserController(Models.DrawmoneyContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            getsession();
            return View();
        }

        public IActionResult UserList()
        {
            getsession();
            var user = db.TbUser.Include(a => a.PreName).Include(a => a.Gender).Include(a => a.Department).Include(a => a.Position).Include(a => a.UserType);
            return View(user);
        }
        [HttpPost]
        public IActionResult Search(string txt)
        {
            getsession();
            var user = db.TbUser.ToList();
            if (txt != null)
                user = db.TbUser.Where(p => p.Username.Contains(txt) || p.Department.DepartmentName.Contains(txt) || p.Firstname.Contains(txt) || p.Lastname.Contains(txt)).Include(a => a.PreName).Include(a => a.Gender).Include(a => a.Department).Include(a => a.Position).Include(a => a.UserType).ToList();
            else return RedirectToAction("UserList", "User");
            return View("UserList", user);
        }


        public IActionResult Register()
        {
            getsession();
            ViewBag.PreNameId = new SelectList(db.TbPrename, "PrenameId", "PreName");
            ViewBag.GenderId = new SelectList(db.TbGender, "GenderId", "GenderName");
            ViewBag.DepartmentId = new SelectList(db.TbDepartment, "DepartmentId", "DepartmentName");
            ViewBag.PositionId = new SelectList(db.TbPosition, "PositionId", "PositionName");
            ViewBag.UserTypeId = new SelectList(db.TbUsertype, "UserTypeId", "UserTypeName");
            return View();
        }
        [HttpPost]
        public IActionResult Register(Models.TbUser model)
        {
           // ModelState.Remove(model.UserId);
            //if (ModelState.IsValid)
           // {
                var chk = db.TbUser.Where(a => a.Username == model.Username).FirstOrDefault();
                if (chk != null)
                {
                    ModelState.AddModelError("", "มีชื่อผู้ใช้นี้อยู้ในระบบเเล้ว");
                    //Clients.RegisterStartupScript(this.GetType(), "alert", "alert('มีชื่อผู้ใช้นี้อยู่แล้ว')",true);
                }
                else
                {
                    if (model.File != null)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            model.File.CopyTo(memoryStream);
                            model.Image = memoryStream.ToArray();
                        }
                    }
                    model.UserTypeId = 1;
                    var user = db.TbUser.Add(model);
                    db.SaveChanges();
                    if (ViewBag.UserId == null)
                    {
                        return RedirectToAction("Login", "User");
                    }
                    else
                    {
                        return RedirectToAction("UserList", "User");
                    }
                }

            // }
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "User");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Models.TbUser model)
        {
            var user = db.TbUser.Where(a => a.Username == model.Username && a.Password == model.Password).FirstOrDefault();
            if (user != null)
            {
                HttpContext.Session.SetString("UserName", user.Firstname + " " + user.Lastname);
                HttpContext.Session.SetInt32("UserId", user.UserId);
                HttpContext.Session.SetString("UserType", user.UserTypeId + "");
                HttpContext.Session.SetString("UserImg", user.Image + "");
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ModelState.AddModelError("", "Username หรือ Password ไม่ถูกต้อง");
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            getsession();
            ViewBag.PreNameId = new SelectList(db.TbPrename, "PrenameId", "PreName");
            ViewBag.GenderId = new SelectList(db.TbGender, "GenderId", "GenderName");
            ViewBag.DepartmentId = new SelectList(db.TbDepartment, "DepartmentId", "DepartmentName");
            ViewBag.PositionId = new SelectList(db.TbPosition, "PositionId", "PositionName");
            ViewBag.UserTypeId = new SelectList(db.TbUsertype, "UserTypeId", "UserTypeName");
            var user = db.TbUser.Where(p => p.UserId == id).FirstOrDefault();
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(Models.TbUser model)
        {

            //แปลงภาพให้เป็นไบนารีก่อน
            if (model.File != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    model.File.CopyTo(memoryStream);
                    model.Image = memoryStream.ToArray();
                }
            }

            db.TbUser.Update(model);
            db.SaveChanges();
            if (HttpContext.Session.GetString("UserType") != "2")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                
                return RedirectToAction("UserList", "User");
            }

        }

        public IActionResult Profile()
        {
            getsession();
            int id = ViewBag.UserId;
            var user = db.TbUser.Where(p => p.UserId == id).Include(a => a.PreName).Include(a => a.Gender).Include(a => a.Department).Include(a => a.Position).Include(a => a.UserType).FirstOrDefault();
            return View(user);
        }
        public IActionResult Details(int id)
        {
            getsession();
            var user = db.TbUser.Where(p => p.UserId == id).Include(a => a.PreName).Include(a => a.Gender).Include(a => a.Department).Include(a => a.Position).Include(a => a.UserType).FirstOrDefault();
            return View(user);
        }

        public IActionResult Delete(int id)
        {
            var user = db.TbUser.Where(p => p.UserId == id).FirstOrDefault();
            try
            {
                db.TbUser.Remove(user);
                db.SaveChanges();
            }
            catch (Exception)
            {
                TempData["Message"] = "No";
            }

                return RedirectToAction("UserList", "User");
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