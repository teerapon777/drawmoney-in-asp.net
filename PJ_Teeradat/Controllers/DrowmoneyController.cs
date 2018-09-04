using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace PJ_Teeradat.Controllers
{
    public class DrowmoneyController : Controller
    {
        private readonly Models.DrawmoneyContext db;
        public DrowmoneyController(Models.DrawmoneyContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            getsession();
            ViewBag.ProvinceId = new SelectList(db.TbProvince, "ProvinceId", "ProvinceName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Models.TbWithdraw model)
        {
            if (ModelState.IsValid)
            {
                model.UserId = HttpContext.Session.GetInt32("UserId");
                model.DateApplicant = DateTime.Now;
                model.StatusId = 1;
                var user = db.TbWithdraw.Add(model);
                db.SaveChanges();
                return RedirectToAction("DrowList");
            }
            return View();
        }

        public IActionResult DrowList()
        {
            getsession();
            int id = ViewBag.UserId;
            //.Include(a => a.UserId).Include(a => a.ProvinceId).Include(a => a.StatusId)
            if (ViewBag.UserType == "1")
            {
                var data = db.TbWithdraw.Where(a=>a.UserId == id).Include(a => a.User).Include(a => a.Province).Include(a => a.Status);
                return View(data);
            }
            else
            {
                var data = db.TbWithdraw.Include(a => a.User).Include(a => a.Province).Include(a => a.Status);
                return View(data);
            }

        }

        [HttpPost]
        public IActionResult Search(string txt)
        {
            getsession();
            var data = db.TbWithdraw.ToList();
            if (txt != null)
                data = db.TbWithdraw.Where(p => p.ProjectName.Contains(txt) || p.Location.Contains(txt) || p.Province.ProvinceName.Contains(txt) || p.User.Firstname.Contains(txt)).Include(a => a.Province).Include(a => a.User).Include(a => a.Status).ToList();
            else return RedirectToAction("DrowList", "Drowmoney");
            return View("DrowList", data);
        }

        public IActionResult Edit(int id)
        {
            getsession();
            ViewBag.StatusId = new SelectList(db.TbStatus, "StatusId", "StatusName");
            ViewBag.UserId = new SelectList(db.TbUser, "UserId", "Firstname","Lastname");
            ViewBag.ProvinceId = new SelectList(db.TbProvince, "ProvinceId", "ProvinceName");
            var data = db.TbWithdraw.Where(p => p.ProjectId == id).Include(a=>a.User).Include(a => a.Status).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Models.TbWithdraw model)
        {
            db.TbWithdraw.Update(model);
            db.SaveChanges();
            return RedirectToAction("DrowList"); 
        }

        public IActionResult Details(int id)
        {
            getsession();
            var data = db.TbWithdraw.Where(p => p.ProjectId == id).Include(a => a.Province).Include(a => a.User).Include(a => a.Status).FirstOrDefault();
            return View(data);
        }

        public IActionResult Delete(int id)
        {
            var data = db.TbWithdraw.Where(p => p.ProjectId == id).FirstOrDefault();
            try
            {
                db.TbWithdraw.Remove(data);
                db.SaveChanges();
            }
            catch (Exception)
            {
                TempData["Message"] = "No";
            }
            return RedirectToAction("DrowList");
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