using DataModel;
using EmployeeRegistration.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeRegistration.Filter
{
    public class CustomExceptionFilter : FilterAttribute, IExceptionFilter
    {
        LoggerRepository _loggerRepository = new LoggerRepository(); 
        public void OnException(ExceptionContext filterContext)
        {
            Logger logger = new Logger();
            logger.InnerException = Convert.ToString(filterContext.Exception.InnerException);
            logger.StackTrace = Convert.ToString(filterContext.Exception.StackTrace);
            logger.Controller = Convert.ToString(filterContext.Controller);
            logger.RawUrl =Convert.ToString(((System.Web.HttpRequestWrapper)((System.Web.HttpContextWrapper)filterContext.HttpContext).Request).RawUrl);
            logger.Message = Convert.ToString(filterContext.Exception.Message);

            _loggerRepository.LogExceptionToDB(logger);

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error"
            };
            filterContext.ExceptionHandled = true;
        }
    }
}