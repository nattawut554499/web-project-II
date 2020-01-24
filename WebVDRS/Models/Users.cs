using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebVDRS.Models
{
    public class Administrator
    {
        [Key]
        public int Id { get; set; }
        public string AdminUser { get; set; }
        public string AdminPassword { get; set; }
        public string AdminName { get; set; }
        public string AdminLastname { get; set; }
    }

    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string StudentId { get; set; }
        public string StudentPassword { get; set; }
        public string StudentName { get; set; }
        public string StudentLastname { get; set; }
        public int StudentStatus { set; get; }

        public string StudentMajor { get; set; }
        public string StudentFaculty { get; set; }
        public string StudyStatus { get; set; }
        public string StudyGender { get; set; }
    }

    public class SecurityGuard
    {
        [Key]
        public int Id { get; set; }
        public string GuardId { get; set; }
        public string GuardUsername { get; set; }
        public string GuardPassword { get; set; }
        public string GuardName { get; set; }
        public string GuardLastname { get; set; }

    }

    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string AccountUsername { get; set; }
        public string AccountPassword { get; set; }
        public int AccountRole { get; set; }
        public int AccountId { get; set; }
        // role 0 = admin ,1 = student ,2 = security

    }
}