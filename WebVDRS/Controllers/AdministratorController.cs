using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebVDRS.Models;

namespace WebVDRS.Controllers
{
    public class AdministratorController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Reporting()
        {
            
            return View();
        }
        public ActionResult AddSecurityGuard()
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
        public ActionResult getAllReport()
        {
            using(BlogDbContext db = new BlogDbContext())
            {
                var fetchs = db.reportings.OrderByDescending(x => x.SubmitTime).ToList();
                return new JsonResult { Data = fetchs, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            
        }
        [HttpPost]
        public ActionResult countNewReport()
        {
            using(BlogDbContext db = new BlogDbContext())
            {
                var fetchs = db.reportings.Where(a => a.IsRecent == true).ToList();
                var count = fetchs.Count();
                return new JsonResult { Data = count, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        [HttpPost]
        public ActionResult seenNewReport(string ReportingId)
        {
            using (BlogDbContext db = new BlogDbContext())
            {
                var fetchs = db.reportings.Where(a => a.ReportingId == ReportingId).FirstOrDefault();
                if(fetchs != null)
                {
                    fetchs.IsRecent = false;
                }
                db.SaveChanges();
                return new JsonResult { Data = true, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        [HttpPost]
        public ActionResult addSecurityGuard(SecurityGuard guard)
        {
            using (BlogDbContext db = new BlogDbContext())
            {
                var isSameUser = db.accounts.Where(a => a.AccountUsername == guard.GuardUsername).FirstOrDefault();
                if(isSameUser == null)
                {
                    // Username not the same
                    // Generate ID
                    StringBuilder strBuilder = new StringBuilder();
                    Enumerable
                       .Range(65, 26)
                        .Select(e => ((char)e).ToString())
                        .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
                        .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                        .OrderBy(e => Guid.NewGuid())
                        .Take(11)
                        .ToList().ForEach(e => strBuilder.Append(e));
                    string id = strBuilder.ToString();

                    guard.GuardId = id;

                    db.securityGuards.Add(guard);
                    db.SaveChanges();

                    var isAdded = addGuardAccount(guard.GuardUsername);
                    if (isAdded)
                    {
                        return new JsonResult { Data = new { status = true, name = guard.GuardName, lastname = guard.GuardLastname, statusCode = 0 }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                    }
                    else
                    {
                        return new JsonResult { Data = new { status = false, statusCode = 99 }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                    }
                }
                else
                {
                    // same
                    return new JsonResult { Data = new { status = false, statusCode = 1 }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
        }
        public bool addGuardAccount(string username)
        {
            using (BlogDbContext db = new BlogDbContext())
            {
                var guardsInfo = db.securityGuards.Where(a => a.GuardUsername == username).FirstOrDefault();
                if(guardsInfo != null)
                {
                    Account acc = new Account();
                    acc.AccountId = guardsInfo.Id; // this field is useless
                    acc.AccountUsername = guardsInfo.GuardUsername;
                    acc.AccountPassword = guardsInfo.GuardPassword;
                    acc.AccountRole = 2;

                    db.accounts.Add(acc);
                    db.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}