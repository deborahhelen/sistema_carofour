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
            //String de conexão ao banco de dados
            string connectionString = "Data Source=MOANE-PC\\SQLEXPRESS;" +
                                      "Initial Catalog=Carofour;" +
                                      "User=sa;" +
                                      "Password=1q2w3e";

           //  string connectionString = "Data Source=CN-PC\\SQLSERVEREXPRESS;" +
           //                           "Initial Catalog=Carofour;" +
           //                           "User=sa;" +
           //                           "Password=1q2w3e";

            //string connectionString = "Data Source=notedeborah\\sqlexpress;" +
            //                          "Initial Catalog=Carofour;" +
            //                          "User=sa;" +
            //                          "Password=deborah@123";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            return conn;
        }

      
        public static void CRUD(SqlCommand command)
        {
            try
            {
                SqlConnection conn = Connect();
                command.Connection = conn;
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                throw new Exception("Erro ao salvar cliente");
            }
            
        }

        public static SqlDataReader Select(SqlCommand command)
        {
            try
            {
                SqlConnection conn = Connect();
                command.Connection = conn;
                SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);

                return dr;
            }
            catch
            {
                return null;
            }
        }
    }
}
