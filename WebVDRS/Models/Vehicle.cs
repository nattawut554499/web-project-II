using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebVDRS.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string Province { get; set; }
        public string Brand { get; set; }
        public string Generation { get; set; }
        public string Color { get; set; }
        public int Type { get; set; }
        public string StudentId { get; set; }
    }

    public class Province
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
        public string Name { get; set; }
    }
}