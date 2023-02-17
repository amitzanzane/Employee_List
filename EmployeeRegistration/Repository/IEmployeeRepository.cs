using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegistration.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeMasterModel> GetAllEmployeeList();
        IEnumerable<Country> GetAllCountries();
        IEnumerable<State> GetAllStatesByCountryId(int countryId);
        
        IEnumerable<City> GetAllCitiesByStateId(int stateId);
        
        string UniqueFieldvalidation(string fieldName,string fieldValue);
        string InsertUpdateEmployee(EmployeeMasterModel emm);
        string DeleteEmployee(int employeeRowID);
    }
}
