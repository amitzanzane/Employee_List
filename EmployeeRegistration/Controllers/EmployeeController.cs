using DataModel;
using EmployeeRegistration.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeRegistration.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BindEmployeeList()
        {
            return Json(new { data = this._employeeRepository.GetAllEmployeeList() }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllCountries()
        {
            return Json(new { data = this._employeeRepository.GetAllCountries() }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllStatesByCountryId(int countryId)
        {
            return Json(new { data = this._employeeRepository.GetAllStatesByCountryId(countryId) }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllCitiesByStateId(int stateId)
        {
            return Json(new { data = this._employeeRepository.GetAllCitiesByStateId(stateId) }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UniqueFieldvalidation(string fieldName,string fieldValue)
        {
            return Content(this._employeeRepository.UniqueFieldvalidation(fieldName, fieldValue), "text/plain");
        }
        public ActionResult InsertUpdateEmployee(EmployeeMasterModel emm)
        {
            return Content(this._employeeRepository.InsertUpdateEmployee(emm), "text/plain");
        }
        public ActionResult DeleteEmployee(int employeeRowID)
        {
            return Content(this._employeeRepository.DeleteEmployee(employeeRowID), "text/plain");
        }
    }
}