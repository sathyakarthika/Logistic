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
        string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ToString();
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
