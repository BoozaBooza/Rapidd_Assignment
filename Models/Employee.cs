using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_Rapidd.Models
{
    public class Employee
    {
        public string EmpID { get; internal set; }
        public string FullName { get; set; }
        public string OfficeLocation { get; set; }
        public bool IsActive { get; set; }
        public int Position { get; set; }
        public string PermanentAddress { get; set; }
        public bool Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string DateOfJoining { get; set; }
        public string DateOfLeaving { get; set; }
        public double Experience { get; set; }
        public string EmailId { get; set; }
        public string LanguagesKnown { get; set; }
    }
}