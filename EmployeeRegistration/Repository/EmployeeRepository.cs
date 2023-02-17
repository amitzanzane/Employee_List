using DataAccess.Controller;
using DataModel;
using ImageResizer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace EmployeeRegistration.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public string DeleteEmployee(int employeeRowID)
        {
            EmployeeCtr emp = new EmployeeCtr();
            return emp.DeleteEmployee(employeeRowID);
        }

        public IEnumerable<City> GetAllCitiesByStateId(int stateId)
        {
            List<City> cities = new List<City>();
            EmployeeCtr employeeCtr = new EmployeeCtr();
            cities = employeeCtr.GetAllCitiesByStateId(stateId);
            return cities;
        }
        public IEnumerable<Country> GetAllCountries()
        {
            List<Country> countries = new List<Country>();
            EmployeeCtr employeeCtr = new EmployeeCtr();
            countries = employeeCtr.GetAllCountries();
            return countries;
        }

        public IEnumerable<EmployeeMasterModel> GetAllEmployeeList()
        {
            List<EmployeeMasterModel> employees = new List<EmployeeMasterModel>();
            EmployeeCtr employeeCtr = new EmployeeCtr();
            employees = employeeCtr.GetAllEmployeeList();
            return employees;
        }

        public IEnumerable<State> GetAllStatesByCountryId(int countryId)
        {
            List<State> states = new List<State>();
            EmployeeCtr employeeCtr = new EmployeeCtr();
            states = employeeCtr.GetAllStatesByCountryId(countryId);
            return states;
        }


        public string InsertUpdateEmployee(EmployeeMasterModel model)
        {
            var file = model.ImageFile;
            
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                if (!extension.Contains(".png") && !extension.Contains(".jpg") && !extension.Contains(".jpeg"))
                {
                    return "";
                }
                string fileName = model.firstName + "_" + Convert.ToString(DateTime.Now).Replace(":", "").Replace("-", "").Replace(" ", "").Replace("/", "");
                string url = "Uploads/Employee/" + fileName + "" + extension;
                model.profileImage = url;

                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file.FileName);
                file.SaveAs(HttpContext.Current.Server.MapPath("/Uploads/Employee/" + fileName + "" + extension));

                string path = System.IO.Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads/Employee"), fileName + "" + extension);
                ResizeSettings resizeSetting = new ResizeSettings
                {
                    Height = 400,
                    Mode = FitMode.Stretch,
                    Format = "png"
                };
                ImageBuilder.Current.Build(path, path, resizeSetting);
            }
            EmployeeCtr employeeCtr = new EmployeeCtr();
            string i = employeeCtr.InsertUpdateEmployee(model);
            return i;
        }

        public string UniqueFieldvalidation(string fieldName, string fieldValue)
        {
            string result = "";
            EmployeeCtr employeeCtr = new EmployeeCtr();
            int i = employeeCtr.UniqueFieldvalidation(fieldName, fieldValue);
            if (i > 0)
            {
                return result = "value already exist";
            }
            return result = "";
        }
    }
}