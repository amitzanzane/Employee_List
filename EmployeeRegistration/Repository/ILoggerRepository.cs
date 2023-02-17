using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegistration.Repository
{
    public interface ILoggerRepository
    {
        void LogExceptionToDB(Logger log);
    }
}
