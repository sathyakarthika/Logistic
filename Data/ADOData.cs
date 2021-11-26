using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ADOData
    {
        string constr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ToString();
        //string constr = @"Data Source=.\SQLEXPRESS; AttachDbFilename=|DataDirectory|\Logistic.mdf; Integrated Security=True; Connect Timeout=30; User Instance=True";
        private SqlConnection con;
        private SqlCommand com;
        public int ExecuteNonQuery(string SpName, SqlParameter[] sqlParameters)
        {
            con = new SqlConnection(constr);
            com = new SqlCommand(SpName, con);
            com.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter sqlParam in sqlParameters)
            {
                com.Parameters.AddWithValue(sqlParam.ParameterName, sqlParam.Value);
            }
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public DataTable ExecuteReaderWithDatatable(string SpName, SqlParameter[] sqlParameters)
        {
            DataTable objResult = new DataTable();
            con = new SqlConnection(constr);
            com = new SqlCommand(SpName, con);
            com.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter sqlParam in sqlParameters)
            {
                com.Parameters.AddWithValue(sqlParam.ParameterName, sqlParam.Value);
            }
            con.Open();
            objResult.Load(com.ExecuteReader());
            con.Close();
            return objResult;
        }

        public string ExecuteScalar(string SpName, SqlParameter[] sqlParameters)
        {
            string result;
            con = new SqlConnection(constr);
            com = new SqlCommand(SpName, con);
            com.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter sqlParam in sqlParameters)
            {
                com.Parameters.AddWithValue(sqlParam.ParameterName, sqlParam.Value);
            }
            con.Open();
            result = com.ExecuteScalar().ToString();
            con.Close();
            return result;
        }
    }
}
