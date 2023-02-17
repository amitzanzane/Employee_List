using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Logger
    {
        public string InnerException { get; set; }
        public string StackTrace { get; set; }
        public string Controller { get; set; }
        public string RawUrl { get; set; }
        public string Message { get; set; }
    }
}
