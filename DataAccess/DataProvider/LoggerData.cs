using DataAccess.Constants;
using DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataProvider
{
    class LoggerData
    {
        internal void LogExceptionToDB(Logger log)
        {
            DatabaseProcessing db = new DatabaseProcessing();
            SqlCommand cmd = new SqlCommand(LoggerConstants.LogExceptionToDB);
            cmd.Parameters.Add("@InnerException", SqlDbType.VarChar).Value = log.InnerException;
            cmd.Parameters.Add("@StackTrace", SqlDbType.VarChar).Value = log.StackTrace;
            cmd.Parameters.Add("@RawUrl", SqlDbType.VarChar).Value = log.RawUrl;
            cmd.Parameters.Add("@Controller", SqlDbType.VarChar).Value = log.Controller;
            cmd.Parameters.Add("@Message", SqlDbType.VarChar).Value = log.Message;

            db.executeStoredProcedure(cmd);
        }
    }
}
