using DataAccess.Constants;
using DataAccess.DataProvider;
using DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataAccess.DataProvider
{
    class EmployeeData
    {
        string key = "EmployeeList";
        DatabaseProcessing db = new DatabaseProcessing();
        internal DataTable getAllEmployeeList()
        {
            DataTable dt = new DataTable();
            
            if(HttpContext.Current.Cache[key] != null) {
                dt =(DataTable)HttpContext.Current.Cache[key];
                return dt;
            }

            SqlCommand cmd = new SqlCommand(EmployeeConstants.GetAllEmployeeList);
            dt = db.getDataTable(cmd);

            HttpContext.Current.Cache.Insert(key, dt, null, DateTime.Now.AddMinutes(30), System.Web.Caching.Cache.NoSlidingExpiration);

            return dt;
        }

        internal DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(EmployeeConstants.GetAllCountries);
            dt = db.getDataTable(cmd);
            return dt;
        }

        internal DataTable GetAllStatesByCountryId(int countryId)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(EmployeeConstants.GetAllStatesByCountryId);
            cmd.Parameters.Add("@countryId", SqlDbType.Int).Value = countryId;
            dt = db.getDataTable(cmd);
            return dt;
        }
        internal DataTable GetAllCitiesByStateId(int stateId)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(EmployeeConstants.GetAllCitiesByStateId);
            cmd.Parameters.Add("@stateId", SqlDbType.Int).Value = stateId;
            dt = db.getDataTable(cmd);
            return dt;
        }

        internal DataTable UniqueFieldvalidation(string fieldName,string fieldValue)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(EmployeeConstants.UniqueFieldvalidation);
            cmd.Parameters.Add("@fieldName", SqlDbType.VarChar).Value = fieldName;
            cmd.Parameters.Add("@fieldValue", SqlDbType.VarChar).Value = fieldValue;
            dt = db.getDataTable(cmd);
            return dt;
        }

        internal int InsertUpdateEmployee(EmployeeMasterModel model)
        {
            HttpContext.Current.Cache.Remove(key);
            SqlCommand cmd = new SqlCommand(EmployeeConstants.InsertUpdateEmployee);
            cmd.Parameters.Add("@row_Id", SqlDbType.Int).Value = model.row_Id;
            cmd.Parameters.Add("@firstName", SqlDbType.VarChar).Value = model.firstName;
            cmd.Parameters.Add("@lastName", SqlDbType.VarChar).Value = model.lastName;
            cmd.Parameters.Add("@emailAddress", SqlDbType.VarChar).Value = model.emailAddress;
            cmd.Parameters.Add("@mobileNumber", SqlDbType.VarChar).Value = model.mobileNumber;
            cmd.Parameters.Add("@panNumber", SqlDbType.VarChar).Value = model.panNumber;
            cmd.Parameters.Add("@passportNumber", SqlDbType.VarChar).Value = model.passportNumber;
            cmd.Parameters.Add("@dateOfBirth", SqlDbType.VarChar).Value = model.dateOfBirth;
            cmd.Parameters.Add("@dateOfJoinee", SqlDbType.VarChar).Value = model.dateOfJoinee;
            cmd.Parameters.Add("@profileImage", SqlDbType.VarChar).Value = model.profileImage;
            cmd.Parameters.Add("@countryId", SqlDbType.Int).Value = model.countryId;
            cmd.Parameters.Add("@stateId", SqlDbType.Int).Value = model.stateId;
            cmd.Parameters.Add("@cityId", SqlDbType.Int).Value = model.cityId;
            cmd.Parameters.Add("@gender", SqlDbType.Int).Value = model.gender;
            cmd.Parameters.Add("@isActive", SqlDbType.Int).Value = model.isActive;
            return db.executeStoredProcedure(cmd);
        }

        internal int DeleteEmployee(int employeeRowID)
        {
            HttpContext.Current.Cache.Remove(key);
            SqlCommand cmd = new SqlCommand(EmployeeConstants.DeleteEmployee);
            cmd.Parameters.Add("@employeeRowID", SqlDbType.Int).Value = employeeRowID;
            return db.executeStoredProcedure(cmd);
        }
    }
}
