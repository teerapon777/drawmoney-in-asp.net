using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PJ_Teeradat.Controllers
{
    public class DataController : Controller
    {
        private readonly Models.DrawmoneyContext db;
        public DataController(Models.DrawmoneyContext db)
        {
            this.db = db;
        }
        public IActionResult PrenameList()
        {
            getsession();
            var data = db.TbPrename.ToList();
            return View(data);
        }    
        
        // คำนำหน้าชื่อ //
        public IActionResult CreatePrename()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatePrename(Models.TbPrename model)
        {
            db.TbPrename.Add(model);
            db.SaveChanges();
            return RedirectToAction("PrenameList");
        }
        public IActionResult EditPrename(int id)
        {
            var data = db.TbPrename.Where(p => p.PrenameId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public IActionResult EditPrename(Models.TbPrename model)
        {
            db.TbPrename.Update(model);
            db.SaveChanges();
            return RedirectToAction("PrenameList");
        }
        public IActionResult DeletePrename(int id)
        {
            var data = db.TbPrename.Where(p => p.PrenameId == id).FirstOrDefault();
            try
            {
                db.TbPrename.Remove(data);
                db.SaveChanges();
            }
            catch (Exception)
            {
                TempData["Message"] = "No";
            }

            return RedirectToAction("PrenameList");
        }
        // ------------------------ //

        // หน่วยงาน/คณะ //
        public IActionResult DepList()
        {
            getsession();
            var data = db.TbDepartment.ToList();
            return View(data);
        }
        public IActionResult CreateDep()
        {
            getsession();
            return View();
        }
        [HttpPost]
        public IActionResult CreateDep(Models.TbDepartment model)
        {
            db.TbDepartment.Add(model);
            db.SaveChanges();
            return RedirectToAction("DepList");
        }
        public IActionResult EditDep(int id)
        {
            getsession();
            var data = db.TbDepartment.Where(p => p.DepartmentId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public IActionResult EditDep(Models.TbDepartment model)
        {
            db.TbDepartment.Update(model);
            db.SaveChanges();
            return RedirectToAction("DepList");
        }
        public IActionResult DeleteDep(int id)
        {
            var data = db.TbDepartment.Where(p => p.DepartmentId == id).FirstOrDefault();
            try
            {
                db.TbDepartment.Remove(data);
                db.SaveChanges();
            }
            catch (Exception)
            {
                TempData["Message"] = "No";
            }

            return RedirectToAction("DepList");
        }
        // ------------------- //

        //ตำแหน่ง  //

        public IActionResult PositionList()
        {
            getsession();
            var data = db.TbPosition.ToList();
            return View(data);
        }
        public IActionResult CreatePosition()
        {
            getsession();
            return View();
        }
        [HttpPost]
        public IActionResult CreatePosition(Models.TbPosition model)
        {
            db.TbPosition.Add(model);
            db.SaveChanges();
            return RedirectToAction("PositionList");
        }
        public IActionResult EditPosition(int id)
        {
            getsession();
            var data = db.TbPosition.Where(p => p.PositionId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public IActionResult EditPosition(Models.TbPosition model)
        {
            db.TbPosition.Update(model);
            db.SaveChanges();
            return RedirectToAction("PositionList");
        }
        public IActionResult DeletePosition(int id)
        {
            var data = db.TbPosition.Where(p => p.PositionId == id).FirstOrDefault();
            try
            {
                db.TbPosition.Remove(data);
                db.SaveChanges();
            }
            catch (Exception)
            {
                TempData["Message"] = "No";
            }

            return RedirectToAction("PositionList");
        }

        // --------------------- //

        //  เพศ  //

        public IActionResult GenderList()
        {
            getsession();
            var data = db.TbGender.ToList();
            return View(data);
        }
        public IActionResult CreateGender()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateGender(Models.TbGender model)
        {
            db.TbGender.Add(model);
            db.SaveChanges();
            return RedirectToAction("GenderList");
        }
        public IActionResult EditGender(int id)
        {
            var data = db.TbGender.Where(p => p.GenderId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public IActionResult EditGender(Models.TbGender model)
        {
            db.TbGender.Update(model);
            db.SaveChanges();
            return RedirectToAction("GenderList");
        }
        public IActionResult DeleteGender(int id)
        {
            var data = db.TbGender.Where(p => p.GenderId == id).FirstOrDefault();
            try
            {
                db.TbGender.Remove(data);
                db.SaveChanges();
            }
            catch (Exception)
            {
                TempData["Message"] = "No";
            }

            return RedirectToAction("GenderList");
        }

        // --------------------//

        // ผลอนุมัติ  //

        public IActionResult AppList()
        {
            getsession();
            var data = db.TbApprovalresults.ToList();
            return View(data);
        }
        public IActionResult CreateApp()
        {
            getsession();
            return View();
        }
        [HttpPost]
        public IActionResult CreateApp(Models.TbApprovalresults model)
        {
            db.TbApprovalresults.Add(model);
            db.SaveChanges();
            return RedirectToAction("AppList");
        }
        public IActionResult EditApp(int id)
        {
            getsession();
            var data = db.TbApprovalresults.Where(p => p.ApprovalResultsId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public IActionResult EditApp(Models.TbApprovalresults model)
        {
            db.TbApprovalresults.Update(model);
            db.SaveChanges();
            return RedirectToAction("AppList");
        }
        public IActionResult DeleteApp(int id)
        {
            var data = db.TbApprovalresults.Where(p => p.ApprovalResultsId == id).FirstOrDefault();
            try
            {
                db.TbApprovalresults.Remove(data);
                db.SaveChanges();
            }
            catch (Exception)
            {
                TempData["Message"] = "No";
            }

            return RedirectToAction("AppList");
        }

        // ----------------------------- //

        // จังหวัด //

        public IActionResult ProList()
        {
            getsession();
            var data = db.TbProvince.ToList();
            return View(data);
        }
        public IActionResult CreatePro()
        {
            getsession();
            return View();
        }
        [HttpPost]
        public IActionResult CreatePro(Models.TbProvince model)
        {
            db.TbProvince.Add(model);
            db.SaveChanges();
            return RedirectToAction("ProList");
        }
        public IActionResult EditPro(int id)
        {
            getsession();
            var data = db.TbProvince.Where(p => p.ProvinceId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public IActionResult EditPro(Models.TbProvince model)
        {
            db.TbProvince.Update(model);
            db.SaveChanges();
            return RedirectToAction("ProList");
        }
        public IActionResult DeletePro(int id)
        {
            var data = db.TbProvince.Where(p => p.ProvinceId == id).FirstOrDefault();
            try
            {
                db.TbProvince.Remove(data);
                db.SaveChanges();
            }
            catch (Exception)
            {
                TempData["Message"] = "No";
            }

            return RedirectToAction("ProList");
        }

        // ----------------------//

        // สถานะ  //

        public IActionResult StatusList()
        {
            getsession();
            var data = db.TbStatus.ToList();
            return View(data);
        }
        public IActionResult CreateStatus()
        {
            getsession();
            return View();
        }
        [HttpPost]
        public IActionResult CreateStatus(Models.TbStatus model)
        {
            db.TbStatus.Add(model);
            db.SaveChanges();
            return RedirectToAction("StatusList");
        }
        public IActionResult EditStatus(int id)
        {
            getsession();
            var data = db.TbStatus.Where(p => p.StatusId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public IActionResult EditStatus(Models.TbStatus model)
        {
            db.TbStatus.Update(model);
            db.SaveChanges();
            return RedirectToAction("StatusList");
        }
        public IActionResult DeleteStatus(int id)
        {
            var data = db.TbStatus.Where(p => p.StatusId == id).FirstOrDefault();
            try
            {
                db.TbStatus.Remove(data);
                db.SaveChanges();
            }
            catch (Exception)
            {
                TempData["Message"] = "No";
            }

            return RedirectToAction("StatusList");
        }

        // ------------------- //

        // ระดับผู้ใช้  //

        public IActionResult UsTyList()
        {
            getsession();
            var data = db.TbUsertype.ToList();
            return View(data);
        }
        public IActionResult CreateUsTy()
        {
            getsession();
            return View();
        }
        [HttpPost]
        public IActionResult CreateUsTy(Models.TbUsertype model)
        {
            db.TbUsertype.Add(model);
            db.SaveChanges();
            return RedirectToAction("UsTyList");
        }
        public IActionResult EditUsTy(int id)
        {
            getsession();
            var data = db.TbUsertype.Where(p => p.UserTypeId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public IActionResult EditUsTy(Models.TbUsertype model)
        {
            db.TbUsertype.Update(model);
            db.SaveChanges();
            return RedirectToAction("UsTyList");
        }
        public IActionResult DeleteUsTy(int id)
        {
            var data = db.TbUsertype.Where(p => p.UserTypeId == id).FirstOrDefault();
            try
            {
                db.TbUsertype.Remove(data);
                db.SaveChanges();
            }
            catch (Exception)
            {
                TempData["Message"] = "No";
            }

            return RedirectToAction("UsTyList");
        }

        // -------------------- //
        public void getsession()
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            ViewBag.UserType = HttpContext.Session.GetString("UserType");
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            ViewBag.img = HttpContext.Session.GetString("UserImg");
        }
    }
}