using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PJ_Teeradat.Controllers
{
    public class ApproveController : Controller
    {
        private readonly Models.DrawmoneyContext db;
        public ApproveController(Models.DrawmoneyContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Details(int id)
        {
            getsession();
            var data = db.TbWithdraw.Where(p => p.ProjectId == id).Include(a => a.Province).Include(a => a.User).Include(a => a.Status).FirstOrDefault();
            return View(data);
        }
        public IActionResult DetailsDrow(int id)
        {
            getsession();
            var data = db.TbWithdraw.Where(p => p.ProjectId == id).Include(a => a.Province).Include(a => a.User).Include(a => a.Status).FirstOrDefault();
            return View(data);
        }
        public IActionResult ApproveList()
        {
            getsession();
            int id = ViewBag.Userid;
            
            if (ViewBag.UserType == "1")
            {
                var data = db.TbApprove.Where(a=>a.Project.UserId == id).Include(a => a.User).Include(a => a.ApprovalResults).Include(a => a.Project);
                return View(data);
            }
            else
            {
                var data = db.TbApprove.Include(a => a.User).Include(a => a.ApprovalResults).Include(a => a.Project);
                var data2 = db.TbWithdraw.Where(a => a.StatusId == 2).Include(a => a.User).Include(a => a.Province).Include(a => a.Status);
                return View(data);
            } 
        }
        [HttpPost]
        public IActionResult Search(string txt)
        {
            getsession();
            var data = db.TbApprove.ToList();
            if (txt != null)
                data = db.TbApprove.Where(p => p.Project.ProjectName.Contains(txt)).Include(a => a.Project).Include(a => a.User).Include(a => a.ApprovalResults).ToList();
            else return RedirectToAction("ApproveList", "Approve");
            return View("ApproveList", data);
        }
        public IActionResult DrowList()
        {
            getsession();
            var data = db.TbWithdraw.Where(a => a.StatusId == 1).Include(a => a.User).Include(a => a.Province).Include(a => a.Status);
            return View(data);
        }
        public IActionResult CreateApproveY(int id)
        {
            var model = new Models.TbApprove();
            model.ProjectId = id;
            model.UserId = HttpContext.Session.GetInt32("UserId");
            model.ApprovalResultsId = 1;
            model.DateApprove = DateTime.Now;
            var data = db.TbApprove.Add(model);
            db.SaveChanges();
            var data2 = db.TbWithdraw.Where(a => a.ProjectId == id).FirstOrDefault();
            if(data2 != null)
            {
                data2.StatusId = 2;
                db.TbWithdraw.Update(data2);
                db.SaveChanges();
            }
            

            return RedirectToAction("Index","Home");
        }

        public IActionResult CreateApproveN(int id)
        {
            var model = new Models.TbApprove();
            model.ProjectId = id;
            model.UserId = HttpContext.Session.GetInt32("UserId");
            model.ApprovalResultsId = 2;
            model.DateApprove = DateTime.Now;
            var data = db.TbApprove.Add(model);
            db.SaveChanges();
            var data2 = db.TbWithdraw.Where(a => a.ProjectId == id).FirstOrDefault();
            if (data2 != null)
            {
                data2.StatusId = 2;
                db.TbWithdraw.Update(data2);
                db.SaveChanges();
            }


            return RedirectToAction("Index", "Home");
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