using System;
using System.Data.SqlClient;
using System.Configuration;

namespace ElRaDataSQLServer
{
    internal class ConexionDA
    {
        private ConexionDA()
        {
        }

        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionElRa"].ConnectionString);
            conexion.Open();

            return conexion;
        }
    }
}
