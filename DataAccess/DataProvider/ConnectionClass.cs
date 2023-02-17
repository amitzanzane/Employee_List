using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAccess.DataProvider
{
    sealed class ConnectionClass
    {
        public sealed class Singleton
        {

             public string strDBConnection = "";

            private Singleton()
            {
                strDBConnection = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            }
            private static readonly Lazy<Singleton> Instancelock =
                        new Lazy<Singleton>(() => new Singleton());
            public static Singleton GetInstance
            {
                get
                {
                    return Instancelock.Value;
                }
            }

        }
       
        public static string connect()
        {
            Singleton objMySingleton = Singleton.GetInstance;

            string constr = objMySingleton.strDBConnection;
            return constr;
        }
    }
}