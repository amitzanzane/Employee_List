using DataAccess.DataProvider;
using DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Controller
{
    public class EmployeeCtr
    {
        EmployeeData ed = new EmployeeData();
        public List<EmployeeMasterModel> GetAllEmployeeList()
        {
            List<EmployeeMasterModel> employeeList = new List<EmployeeMasterModel>();
            DataTable dt = ed.getAllEmployeeList();
            foreach (DataRow dr in dt.Rows)
            {
                EmployeeMasterModel emm = new EmployeeMasterModel();
                emm.row_Id = Convert.ToInt32(dr["Row_Id"]);
                emm.employeeCode = Convert.ToString(dr["EmployeeCode"]);
                emm.firstName = Convert.ToString(dr["FirstName"]);
                emm.lastName = Convert.ToString(dr["LastName"]);
                emm.countryId = Convert.ToInt32(dr["CountryId"]);
                emm.country = Convert.ToString(dr["CountryName"]);
                emm.stateId = Convert.ToInt32(dr["StateId"]);
                emm.state = Convert.ToString(dr["StateName"]);
                emm.cityId = Convert.ToInt32(dr["CityId"]);
                emm.city = Convert.ToString(dr["CityName"]);
                emm.emailAddress = Convert.ToString(dr["EmailAddress"]);
                emm.mobileNumber = Convert.ToString(dr["MobileNumber"]);
                emm.panNumber = Convert.ToString(dr["PanNumber"]);
                emm.passportNumber = Convert.ToString(dr["PassportNumber"]);
                emm.profileImage = Convert.ToString(dr["ProfileImage"]);
                emm.gender = Convert.ToInt32(dr["Gender"]);
                emm.isActive = Convert.ToInt32(dr["IsActive"]);
                emm.dateOfBirth = Convert.ToString(dr["DateOfBirth"]);
                emm.dateOfJoinee = Convert.ToString(dr["DateOfJoinee"]);
                employeeList.Add(emm);
            }
            return employeeList;
        }

        public string DeleteEmployee(int employeeRowID)
        {
            int i= ed.DeleteEmployee(employeeRowID);
            if (i > 0)
            {
                return "Employee deleted successfully";
            }
            return "Employee not deleted due to some error";
        }

        public int UniqueFieldvalidation(string fieldName,string fieldValue)
        {
            DataTable dt = ed.UniqueFieldvalidation(fieldName, fieldValue);
            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public List<City> GetAllCitiesByStateId(int stateId)
        {
            List<City> cities = new List<City>();
            DataTable dt = ed.GetAllCitiesByStateId(stateId);
            foreach (DataRow dr in dt.Rows)
            {
                City city = new City();
                city.cityId = Convert.ToInt32(dr["cityId"]);
                city.cityName = Convert.ToString(dr["cityName"]);
                cities.Add(city);
            }
            return cities;
        }

        public List<State> GetAllStatesByCountryId(int countryId)
        {
            List<State> states = new List<State>();
            DataTable dt = ed.GetAllStatesByCountryId(countryId);
            foreach (DataRow dr in dt.Rows)
            {
                State state = new State();
                state.stateId = Convert.ToInt32(dr["StateId"]);
                state.stateName = Convert.ToString(dr["StateName"]);
                states.Add(state);
            }
            return states;
        }
        public string InsertUpdateEmployee(EmployeeMasterModel model)
        {
            int i = ed.InsertUpdateEmployee(model);
            if (i>0) {
                return "Employee updated successfully";
            }
            return "Employee not updated";
        }

        public List<Country> GetAllCountries()
        {
            List<Country> countries = new List<Country>();
            DataTable dt = ed.GetAllCountries();
            foreach (DataRow dr in dt.Rows)
            {
                Country country = new Country();
                country.countryId= Convert.ToInt32(dr["Row_Id"]);
                country.countryName= Convert.ToString(dr["CountryName"]);
                countries.Add(country);
            }
            return countries;
        }
    }
}
