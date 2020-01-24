using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebVDRS.Models
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Administrator> administrators { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<SecurityGuard> securityGuards { get; set; }
        public DbSet<Reporting> reportings { get; set; }
        public DbSet<RepeatReport> repeatReports { get; set; }
        public DbSet<Vehicle> vehicles { get; set; }
        public DbSet<Evidence> evidences { get; set; }
        public DbSet<Account> accounts { get; set; }
        public DbSet<Province> provinces { get; set; }
        public DbSet<Place> places { get; set; }
        public DbSet<Charge> charges { get; set; }
        public DbSet<FacultyWU> facultys { get; set; }
        public DbSet<MajorWU> majors { get; set; }
    }
}