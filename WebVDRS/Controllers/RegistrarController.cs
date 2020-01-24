using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.Mvc;
using WebVDRS.Models;

namespace WebVDRS.Controllers
{
    public class RegistrarController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ActionName("UserLogin")]
        public ActionResult UserLogin(string username,string password)
        {
            //BlogDbContext blogDb = new BlogDbContext();
            using (BlogDbContext db = new BlogDbContext()) {
                var u = db.accounts.Where(a => a.AccountUsername == username).FirstOrDefault();
                if (u != null)
                {
                    if (u.AccountPassword == password)
                    {
                        Session["Role"] = u.AccountRole;
                        Session["userName"] = u.AccountUsername;
                        return new JsonResult { Data = u, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                    }
                    else
                    {
                        return Content("notMatch");
                    }
                    
                }
                else
                {
                    //return View("Login");
                    //return RedirectToAction("Login", "Registrar");
                    return Content("notMatch");
                }
            }
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }

        [NonAction]
        public string UpdateAccount()
        {
            return "";
        }
    }
}