using System;
using System.Web;

namespace DataModel
{
    public class EmployeeMasterModel
    {
        public int row_Id { get; set; }
        public string employeeCode { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int countryId { get; set; }
        public int stateId { get; set; }
        public int cityId { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string emailAddress { get; set; }
        public string mobileNumber { get; set; }
        public string panNumber { get; set; }
        public string passportNumber { get; set; }
        public string profileImage { get; set; }
        public HttpPostedFileWrapper ImageFile { get; set; }
        public int gender { get; set; }
        public int isActive { get; set; }
        public string dateOfBirth { get; set; }
        public string dateOfJoinee { get; set; }
    }

}
