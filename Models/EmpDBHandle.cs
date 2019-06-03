using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Assignment_Rapidd.Models
{
    public class EmpDBHandle
    {
        private SqlConnection conn;

        public EmpDBHandle()
        {
            string connStr = ConfigurationManager.ConnectionStrings["RapiddEmpDB"].ConnectionString;
            conn = new SqlConnection(connStr);
        }

        private Employee Employee_Morph(DataRow dr)
        {
            Employee emp = new Employee
            {
                EmpID = Convert.ToString(dr["EmpID"]),
                FullName = Convert.ToString(dr["FullName"]),
                OfficeLocation = Convert.ToString(dr["OfficeLocation"]),
                IsActive = Convert.ToBoolean(dr["IsActive"]),
                Position = Convert.ToInt32(dr["PosID"]),
                PermanentAddress = Convert.ToString(dr["PermanentAddress"]),
                Gender = Convert.ToBoolean(dr["Gender"]),
                DateOfBirth = Convert.ToString(dr["DateOfBirth"]),
                PhoneNumber = Convert.ToString(dr["PhoneNumber"]),
                DateOfJoining = Convert.ToString(dr["DateOfJoining"]),
                DateOfLeaving = Convert.ToString(dr["DateOfLeaving"]),
                Experience = Convert.ToDouble(dr["Experience"]),
                EmailId = Convert.ToString(dr["EmailId"]),
                LanguagesKnown = Convert.ToString(dr["LanguagesKnown"]),
            };
            return emp;
        }

        public List<Employee> GetAllEmployeeData()
        {
            List<Employee> empList = new List<Employee>();
            SqlCommand cmd = new SqlCommand("Get_All_Employee_Details", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            conn.Open();
            sd.Fill(dt);
            conn.Close();

            foreach (DataRow dr in dt.Rows)
            {
                empList.Add(Employee_Morph(dr));
            }
            return empList;
        }

    }
}