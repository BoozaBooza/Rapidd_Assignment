using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Assignment_Rapidd.Models
{
    public class Employee
    {
        [DisplayName("ID")]
        public string empID { get; set; }

        [DisplayName("Name")]
        public string fullName { get; set; }

        [DisplayName("Office")]
        public string officeLocation { get; set; }

        [DisplayName("Active Status")]
        public bool isActive { get; set; }

        [DisplayName("Position")]
        public int position { get; set; }

        [DisplayName("Permanent Address")]
        public string permanentAddress { get; set; }

        [DisplayName("Gender")]
        public bool gender { get; set; }

        [DisplayName("Date Of Birth")]
        public string dateOfBirth { get; set; }

        [DisplayName("Phone Number")]
        public string phoneNumber { get; set; }

        [DisplayName("Date Of Joining")]
        public string dateOfJoining { get; set; }

        [DisplayName("Date Of Leaving")]
        public string dateOfLeaving { get; set; }

        [DisplayName("Experience")]
        public double experience { get; set; }

        [DisplayName("Email ID")]
        public string emailId { get; set; }

        [DisplayName("Languages Known")]
        public string languagesKnown { get; set; }
    }
}