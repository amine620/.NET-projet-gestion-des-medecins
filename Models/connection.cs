using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace siteweb.Models
{
    public class connection
    {
        public SqlConnection con = new SqlConnection();
        public SqlConnection con1 = new SqlConnection();

        public SqlDataAdapter da;
        public DataSet dt = new DataSet();
        public DataTable table = new DataTable();
        public SqlDataReader read;
        public SqlCommand cmd = new SqlCommand();
        public DataTable mer = new DataTable();
        public DataTable mn = new DataTable();
        public DataTable rv = new DataTable();

        public void connécté()
        {
            if (con.State == ConnectionState.Broken || con.State == ConnectionState.Closed)
            {
                con.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\amine\source\repos\siteweb\siteweb\App_Data\aspnet-siteweb-20180308114713.mdf;Initial Catalog=aspnet-siteweb-20180308114713;Integrated Security=True";
                con.Open();
            }
        }
        public void deconecté()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}