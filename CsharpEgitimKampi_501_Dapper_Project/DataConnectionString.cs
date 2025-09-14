using System.Data.SqlClient;

namespace CsharpEgitimKampi_501_Dapper_Project
{
    public static class DataConnectionString
    {
        public static SqlConnection dataConnection() {

            return new SqlConnection(
          "Server= DESKTOP-TUARMBD\\SQLEXPRESS; Initial Catalog=EgitimKampi_501_db; " +
          "Integrated Security=true");
           
        }
    }
}
