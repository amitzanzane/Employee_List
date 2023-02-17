using DataAccess.Controller;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeRegistration.Repository
{
    public class LoggerRepository : ILoggerRepository
    {
        public void LogExceptionToDB(Logger log)
        {
            LoggerCtr loggerCtr = new LoggerCtr();
            loggerCtr.LogExceptionToDB(log);
        }
    }
}