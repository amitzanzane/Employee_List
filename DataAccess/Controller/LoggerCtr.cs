using DataAccess.DataProvider;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Controller
{
    public class LoggerCtr
    {
        public void LogExceptionToDB(Logger log)
        {
            LoggerData loggerData = new LoggerData();
            loggerData.LogExceptionToDB(log);
        }
    }
}
