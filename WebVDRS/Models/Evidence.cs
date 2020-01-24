using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebVDRS.Models
{
    public class Evidence
    {
        [Key]
        public int Id { get; set; }
        public string FullPath { get; set; }
        public string FileName { get; set; }
        public string ReportingId { get; set; }
        public string Extension { get; set; }
        public string FileType { get; set; }
    }

    public class FileUpload
    {
        public IEnumerable<HttpPostedFileBase> FileEvidences { get; set; }
        public string FileReporter { get; set; }
        public string FileReportId { get; set; }
        public string RoleReporter { get; set; }
    }
}