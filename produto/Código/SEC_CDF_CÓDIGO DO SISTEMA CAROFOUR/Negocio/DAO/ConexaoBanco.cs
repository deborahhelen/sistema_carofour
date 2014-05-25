using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Negocio.DAO
{
    public class ConexaoBanco
    {
        public static SqlConnection Connect()
        {
            string connectionString = "Data Source=JUNINHO-PC;" +
                                      "Initial Catalog=Carofour;" +
                                      "User=sa;" +
                                      "Password=juninho007";
            
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            return conn;
        }

        public static void CRUD(SqlCommand command)
        {
            SqlConnection conn = Connect();
            command.Connection = conn;
            command.ExecuteNonQuery();
            conn.Close();
        }

        public static SqlDataReader Select(SqlCommand command)
        {
            SqlConnection conn = Connect();
            command.Connection = conn;
            SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            return dr;
        }
    }
}
