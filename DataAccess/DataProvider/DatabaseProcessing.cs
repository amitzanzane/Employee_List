using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess.DataProvider
{
    class DatabaseProcessing
    {
        private string Constr = ConnectionClass.connect();
        
        private StringBuilder stringBuilder = new StringBuilder();

        internal DataTable getDataTable(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Constr))
            {
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                con.Open();
                da.Fill(dt);
                con.Close();
            }
            return dt;
        }

        internal DataSet getDataSet(SqlCommand cmd)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(Constr))
            {
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                con.Open();
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }

        internal int getOutputParam(SqlCommand cmd, SqlParameter output)
        {
            int returnValue = 0;
            using (SqlConnection con = new SqlConnection(Constr))
            {
                con.InfoMessage += new SqlInfoMessageEventHandler(myConnection_InfoMessage);
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                cmd.ExecuteNonQuery();
                returnValue = Convert.ToInt32(output.Value);

                con.Close();
            }
            return returnValue;
        }

        private void myConnection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            stringBuilder.AppendLine(e.Message);
        }

        internal int executeStoredProcedure(SqlCommand cmd)
        {
            int returnValue = 0;
            using (SqlConnection con = new SqlConnection(Constr))
            {
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                returnValue = cmd.ExecuteNonQuery();
                con.Close();
            }
            return returnValue;
        }

        internal DataTable executeStoredProcedureAndFill(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Constr))
            {
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                con.Open();
                da.Fill(dt);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return dt;
        }

        internal string getOutputParamString(SqlCommand cmd, SqlParameter output)
        {
            string returnValue = string.Empty; ;
            using (SqlConnection con = new SqlConnection(Constr))
            {
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                cmd.ExecuteNonQuery();
                returnValue = (output.Value).ToString();

                con.Close();
            }
            return returnValue;
        }

        internal object executeScalarProcedure(SqlCommand cmd)
        {
            object returnValue = null;
            using (SqlConnection con = new SqlConnection(Constr))
            {
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                returnValue = cmd.ExecuteScalar();
                con.Close();
            }
            return returnValue;
        }
    }
}