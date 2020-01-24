using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebVDRS.Models;

namespace WebVDRS.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Reporting()
        {
            return View();
        }
        public ActionResult Information()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetInitialData()
        {
            InitialData initial = new InitialData();
            var initPlace = initial.getListPlace();
            var initCharge = initial.getListCharge();
            var initProvince = initial.getListProvince();
            object[] objInit = { initPlace, initCharge, initProvince };

            return new JsonResult { Data = objInit, JsonRequestBehavior = JsonRequestBehavior.AllowGet }; 
        }

        [HttpPost]
        public ActionResult GetAllReport()
        {
            
            using(BlogDbContext db  = new BlogDbContext())
            {
                var fetchs = db.reportings.Where(a => a.Reporter == "58114232").OrderByDescending(x => x.SubmitTime).ToList();
                //var fetchs = db.reportings.OrderByDescending(a => a.Date).Take(5).ToList();
                //var fetchs = db.reportings.Where(a => a.Reporter == "58114232").OrderByDescending(x => x.Date).ThenByDescending(x => x.Time).ToList();
                //var fetchs = db.reportings.OrderByDescending(x => x.Date).ThenByDescending(x => x.Time).ToList();
                //var fetchs = db.reportings.OrderByDescending(x => x.SubmitTime).ToList();
                return new JsonResult { Data = fetchs, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        [HttpPost]
        public ActionResult AddReport(Reporting reporting)
        {
            string reportId = Guid.NewGuid().ToString();
            string reporter = "58114232";//Session["userName"].ToString();
            reporting.ReportingId = reportId;
            reporting.Reporter = reporter;
            reporting.SubmitTime = DateTime.Now;

            using (BlogDbContext db = new BlogDbContext())
            {
                db.reportings.Add(reporting);
                db.SaveChanges();
            }
            
            return new JsonResult { Data = new { callbackId = reportId, callbackReporter = reporter }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public ActionResult Addprov(Province province)
        {
            using (BlogDbContext db = new BlogDbContext())
            {
                db.provinces.Add(province);
                db.SaveChanges();
            }
            return new JsonResult { Data = "ok", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}