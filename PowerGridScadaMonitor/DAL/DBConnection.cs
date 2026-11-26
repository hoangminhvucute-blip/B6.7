using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public class DBConnection
    {
        protected static string ConnectionString
        {
            get
            {
                var conn = ConfigurationManager.ConnectionStrings["PowerGridScadaDB"]?.ConnectionString;
                return !string.IsNullOrWhiteSpace(conn)
                    ? conn
                    : @"Data Source=.;Initial Catalog=PowerGridScadaDB;Integrated Security=True;TrustServerCertificate=True;";
            }
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
