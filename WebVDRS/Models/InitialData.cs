using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebVDRS.Models
{
    public class InitialData
    {
        private object ListPlace;
        private object ListCharge;
        private object ListProvince;

        public object getListPlace()
        {
            if (ListPlace != null)
            {
                return ListPlace;
            }
            else
            {
                setListPlace();
                return ListPlace;
            }

        }
        public object getListCharge()
        {
            if (ListCharge != null)
            {
                return ListCharge;
            }
            else
            {
                setListCharge();
                return ListCharge;
            }
        }
        public object getListProvince()
        {
            if (ListProvince != null)
            {
                return ListProvince;
            }
            else
            {
                setListProvince();
                return ListProvince;
            }
        }
        public void setListPlace()
        {
            using (BlogDbContext db = new BlogDbContext())
            {
                ListPlace = db.places.ToList();
            }
        }
        public void setListCharge()
        {
            using (BlogDbContext db = new BlogDbContext())
            {
                ListCharge = db.charges.ToList();
            }
        }
        public void setListProvince()
        {
            using (BlogDbContext db = new BlogDbContext())
            {
                ListProvince = db.provinces.ToList();
            }
        }
    }
    public class FacultyWU
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class MajorWU
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string FacultyValue { get; set; }
    }
}