using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebVDRS.Models;

namespace WebVDRS.Controllers
{
    public class InitialWUController : Controller
    {
        // GET: InitialWU
        public ActionResult ForTestingSystem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetFaculty()
        {
            using (BlogDbContext db = new BlogDbContext())
            {
                var faculty = db.facultys.ToList();
                //for (int i =0; i < faculty.Count; i++)
                //{
                //    faculty[i].Name = faculty[i].Name.Trim().Replace("\r",string.Empty);
                //    faculty[i].Name = faculty[i].Name.Trim().Replace("\n", string.Empty);
                //    faculty[i].Name = faculty[i].Name.Replace(Environment.NewLine, string.Empty);
                //}
                //db.SaveChanges();
                return new JsonResult { Data = faculty, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        [HttpPost]
        public ActionResult GetMajor()
        {
            using (BlogDbContext db = new BlogDbContext())
            {
                var major = db.majors.ToList();
                //for (int i = 0; i < major.Count; i++)
                //{
                //    major[i].Name = major[i].Name.Trim().Replace("\r", string.Empty);
                //    major[i].Name = major[i].Name.Trim().Replace("\n", string.Empty);
                //    major[i].Name = major[i].Name.Replace(Environment.NewLine, string.Empty);
                //}
                //db.SaveChanges();
                return new JsonResult { Data = major, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        [HttpPost]
        public ActionResult addStudent(Student student)
        {
            using (BlogDbContext db = new BlogDbContext())
            {
                string pass = student.StudentNameEng + student.StudentLastnameEng;
                pass = pass.ToLower();
                student.StudentPassword = Crypto.Hash(pass);
                db.students.Add(student);
                db.SaveChanges();
                Account acc = new Account();
                
                acc.AccountUsername = student.StudentId;
                acc.AccountPassword = student.StudentPassword;
                acc.AccountRole = 1;
                var mystatus = addStudentAccount(acc);
                return new JsonResult { Data = new { status = mystatus}, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        public bool addStudentAccount(Account account)
        {
            using (BlogDbContext db = new BlogDbContext())
            {
                db.accounts.Add(account);
                db.SaveChanges();
                return true;
            }     
        }
    }
}