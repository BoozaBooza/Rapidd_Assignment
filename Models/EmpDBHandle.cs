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
            conn.Open();
        }

        private Employee Employee_Morph(DataRow dr)
        {
            Employee emp = new Employee
            {
                empID = Convert.ToString(dr["EmpID"]),
                fullName = Convert.ToString(dr["FullName"]),
                officeLocation = Convert.ToString(dr["OfficeLocation"]),
                isActive = Convert.ToBoolean(dr["IsActive"]),
                position = Convert.ToInt32(dr["PosID"]),
                permanentAddress = Convert.ToString(dr["PermanentAddress"]),
                gender = Convert.ToBoolean(dr["Gender"]),
                dateOfBirth = Convert.ToString(dr["DateOfBirth"]),
                phoneNumber = Convert.ToString(dr["PhoneNumber"]),
                dateOfJoining = Convert.ToString(dr["DateOfJoining"]),
                dateOfLeaving = Convert.ToString(dr["DateOfLeaving"]),
                experience = Convert.ToDouble(dr["Experience"]),
                emailId = Convert.ToString(dr["EmailId"]),
                languagesKnown = Convert.ToString(dr["LanguagesKnown"]),
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

            sd.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                empList.Add(Employee_Morph(dr));
            }
            return empList;
        }

        public Employee GetEmployeeDataByID(string id)
        {
            Employee emp = new Employee();
            SqlCommand cmd = new SqlCommand("Get_Employee_Details_By_ID", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpID", id);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                emp = Employee_Morph(dr);
            }
            return emp;
        }
        public List<EmpPosition> GetEmployeePositions()
        {
            List<EmpPosition> empPosList = new List<EmpPosition>();
            SqlCommand cmd = new SqlCommand("Get_All_Employee_Positions", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                empPosList.Add(EmpPosition_Morph(dr));
            }

            return empPosList;
        }

        private EmpPosition EmpPosition_Morph(DataRow dr)
        {
            EmpPosition empPos = new EmpPosition
            {
                posID = Convert.ToInt32(dr["PosID"]),
                title = Convert.ToString(dr["Title"])
            };
            return empPos;
        }
        public List<OfficeLocation> GetOfficeLocations()
        {
            List<OfficeLocation> officeLocList = new List<OfficeLocation>();
            SqlCommand cmd = new SqlCommand("Get_All_Office_Locations", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                officeLocList.Add(OfficeLocation_Morph(dr));
            }

            return officeLocList;
        }

        private OfficeLocation OfficeLocation_Morph(DataRow dr)
        {
            OfficeLocation officeLoc = new OfficeLocation
            {
                officeLocation = Convert.ToString(dr["OfficeLocation"]),
                officeAddress = Convert.ToString(dr["OfficeAddress"])
            };
            return officeLoc;
        }

        #region Edit Employee Details
        public bool UpdateEmployeeDetails(Employee emp)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Update_Employee_Details", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpID", emp.empID);
                cmd.Parameters.AddWithValue("@FullName", emp.fullName);
                cmd.Parameters.AddWithValue("@OfficeLocation", emp.officeLocation);
                cmd.Parameters.AddWithValue("@IsActive", emp.isActive);
                cmd.Parameters.AddWithValue("@Position", emp.position);
                cmd.Parameters.AddWithValue("@PermanentAddress", emp.permanentAddress);
                cmd.Parameters.AddWithValue("@Gender", emp.gender);
                cmd.Parameters.AddWithValue("@DateOfBirth", System.DateTime.Parse(emp.dateOfBirth));
                cmd.Parameters.AddWithValue("@PhoneNumber", emp.phoneNumber);
                cmd.Parameters.AddWithValue("@DateOfJoining", System.DateTime.Parse(emp.dateOfJoining));
                cmd.Parameters.AddWithValue("@DateOfLeaving", System.DateTime.Parse(emp.dateOfLeaving));
                cmd.Parameters.AddWithValue("@Experience", emp.experience);
                cmd.Parameters.AddWithValue("@EmailID", emp.emailId);
                cmd.Parameters.AddWithValue("@LanguagesKnown", emp.languagesKnown);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Add Employee
        public void AddEmployee(Employee emp)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("Insert_Employee_Details", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpID", emp.empID);
                cmd.Parameters.AddWithValue("@FullName", emp.fullName);
                cmd.Parameters.AddWithValue("@OfficeLocation", emp.officeLocation);
                cmd.Parameters.AddWithValue("@IsActive", emp.isActive);
                cmd.Parameters.AddWithValue("@Position", emp.position);
                cmd.Parameters.AddWithValue("@PermanentAddress", emp.permanentAddress);
                cmd.Parameters.AddWithValue("@Gender", emp.gender);
                cmd.Parameters.AddWithValue("@DateOfBirth", System.DateTime.Parse(emp.dateOfBirth));
                cmd.Parameters.AddWithValue("@PhoneNumber", emp.phoneNumber);
                cmd.Parameters.AddWithValue("@DateOfJoining", System.DateTime.Parse(emp.dateOfJoining));
                cmd.Parameters.AddWithValue("@DateOfLeaving", System.DateTime.Parse(emp.dateOfLeaving));
                cmd.Parameters.AddWithValue("@Experience", emp.experience);
                cmd.Parameters.AddWithValue("@EmailID", emp.emailId);
                cmd.Parameters.AddWithValue("@LanguagesKnown", emp.languagesKnown);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        #region Delete Employee
        public void DeleteEmployee(string empID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Delete_Employee_Details_By_ID", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@empID", empID);

                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
            }
        }
        #endregion
    }
}