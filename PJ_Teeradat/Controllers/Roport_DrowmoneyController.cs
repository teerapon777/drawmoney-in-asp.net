using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report.Mvc;
using Stimulsoft.Report.Web;
using System;
using System.Data;
using System.IO;

namespace PJ_Teeradat.Controllers
{
    public class Roport_DrowmoneyController : Controller
    {
        public IActionResult Index()
        {
            getsession();
            return View();
        }
        public IActionResult GetReport()
        {
            getsession();
            var report = new StiReport();
            var path = StiNetCoreHelper.MapPath(this, "Reports\\Report_Drowmoney.mrt");
            report.Load(path);

            return StiNetCoreViewer.GetReportResult(this, report);
        }

        public IActionResult ViewerEvent()
        {
            getsession();
            return StiNetCoreViewer.ViewerEventResult(this);
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