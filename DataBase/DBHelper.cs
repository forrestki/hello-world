using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QYH.BlukInsertTest.DataBase
{
    public class DBHelper
    {
        public string connectionString = "Server=.;Database=QYHDB;User ID=sa;Password=123456;Trusted_Connection=False;";

        public void Excute(string sql)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.CommandTimeout = 0;
            command.Connection = conn;
            command.CommandText = sql;
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }
    }
}
