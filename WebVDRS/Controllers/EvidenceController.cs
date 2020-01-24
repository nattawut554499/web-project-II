using WebVDRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using System.Text;

namespace WebVDRS.Controllers
{
    public class EvidenceController : Controller
    {
        // GET: Evidence
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadFile(FileUpload fileUpload)
        {
            // fileUpload.* get from form HTML
            string createPath = Server.MapPath(string.Format("~/Evidences/{0}/{1}/{2}",fileUpload.RoleReporter,fileUpload.FileReporter,fileUpload.FileReportId)); 
            var savePath = "";
            var fileName = "";
            var ext = "";
            string servPath = string.Format("~/Evidences/{0}/{1}/{2}/", fileUpload.RoleReporter, fileUpload.FileReporter, fileUpload.FileReportId);
            try
            {
                Evidence evidence = new Evidence();
                evidence.ReportingId = fileUpload.FileReportId;

                foreach (var file in fileUpload.FileEvidences)
                {
                    if (file.ContentLength > 0)
                    {
                        var ct = file.ContentType;
                        if (ct == "image/jpg" ||
                            ct == "image/png" ||
                            ct == "video/mp4" ||
                            ct == "video/quicktime" ||
                            ct == "image/jpeg" ||
                            ct == "image/bmp" ||
                            ct == "video/x-flv" ||
                            ct == "video/3gpp" ||
                            ct == "video/x-msvideo" ||
                            ct == "video/x-ms-wmv")
                        {
                            StringBuilder stringBuilder = new StringBuilder(file.ContentType);
                            if (stringBuilder[0] == 'i')
                            {
                                evidence.FileType = "image";
                            }
                            else
                            {
                                evidence.FileType = "video";
                            }
                            Directory.CreateDirectory(createPath);
                            fileName = Guid.NewGuid().ToString();
                            ext = Path.GetExtension(file.FileName);
                            savePath = Path.Combine(createPath, fileName + ext);
                            file.SaveAs(savePath);
                            evidence.FileName = fileName;
                            evidence.Extension = ext;
                            evidence.FullPath = servPath + fileName + ext;

                            savePathEvidences(evidence);   
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }catch(Exception e)
            {
                return Content(e.ToString());
            }
            finally
            {

            }
            return RedirectToAction("Reporting","Student");
        }
        public void savePathEvidences(Evidence evidence)
        {
            using (BlogDbContext db = new BlogDbContext())
            {
                try
                {
                    db.evidences.Add(evidence);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
        [HttpPost]
        public ActionResult getPreviewEvidence(string ReportingId)
        {
            using (BlogDbContext db = new BlogDbContext())
            {
                var Pre = db.evidences.Where(a => a.ReportingId == ReportingId  ).FirstOrDefault();
                if (Pre != null)
                {
                    Pre.FullPath = Pre.FullPath.TrimStart('~');
                    
                    return new JsonResult { Data = Pre, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
            return null;
        }
        [HttpPost]
        public ActionResult getViewEvidence(string ReportingId)
        {
            using (BlogDbContext db = new BlogDbContext())
            {
                var Ev = db.evidences.Where(a => a.ReportingId == ReportingId).ToList();
                if(Ev != null)
                {
                    for (int i = 0; i < Ev.Count; i++)
                    {
                        Ev[i].FullPath =  Ev[i].FullPath.TrimStart('~');
                    }
                    return new JsonResult { Data = Ev, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
            return null;
        }
    }
}