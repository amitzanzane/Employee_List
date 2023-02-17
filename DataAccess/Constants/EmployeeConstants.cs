using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Constants
{
    class EmployeeConstants
    {
        internal static string DeleteEmployee { get { return "stp_Emp_DeleteEmployee"; } }
        internal static string InsertUpdateEmployee { get { return "stp_Emp_InsertUpdateEmployee"; } }
        internal static string UniqueFieldvalidation { get { return "stp_Emp_IsDuplicateField"; } }
        internal static string GetAllEmployeeList { get { return "stp_Emp_GetAllEmployees"; } }
        internal static string GetAllCountries { get { return "stp_Emp_GetAllCountries"; } }
        internal static string GetAllStatesByCountryId { get { return "stp_Emp_GetAllStatesByCountryId"; } }
        internal static string GetAllCitiesByStateId { get { return "stp_Emp_GetAllCitiesByStateId"; } }
    }
}
