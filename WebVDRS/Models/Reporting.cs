using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebVDRS.Models
{
    public class Reporting
    {
        [Key]
        public int Id { get; set; }
        public string ReportingId { get; set; }
        public string RegistrationNumber { get; set; }
        public string Province { get; set; }
        public string SuspectInfo { get; set; }
        public string Place { get; set; }
        public string AnotherPlace { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        // ลักษณะการกระทำความผิด
        public string ChargeType { get; set; }
        public string AnotherCharge { get; set; }
        public string Reporter { get; set; }
        public bool IsRecent { get; set; }
        public Nullable<DateTime> SubmitTime { get; set; }
        public int Role { get; set; }
        // role 0 = admin ,1 = student ,2 = security

        public string SuspectStudentId { get; set; }
        public string SuspectFirstName { get; set; }
        public string SuspectLastName { get; set; }
        public string SuspectMajor { get; set; }
        public string SuspectFaculty { get; set; }
        public string VehicleType { get; set; }
        public bool IsTheSameCase { get; set; }
    }

    public class RepeatReport
    {
        [Key]
        public int Id { get; set; }
        public string RepeatReportId { get; set; }
    }

    public class Place
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
        public string Name { get; set; }
    }

    public class Charge
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
        public string Name { get; set; }
    }
}