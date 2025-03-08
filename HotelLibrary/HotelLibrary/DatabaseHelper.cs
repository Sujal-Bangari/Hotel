using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace HotelLibrary
{
    public class DatabaseHelper
    {
        private string conn = "Server=WIN2019;Database=HotelAppDb;Trusted_Connection=True;";
        public void ExecuteQuery(string query)
        {
            using(SqlConnection sc=new SqlConnection(conn))
            {
                sc.Open();
                using(SqlCommand scmd=new SqlCommand(query, sc))
                {
                    scmd.ExecuteNonQuery();
                }
            }
        }
        public DataTable GetData(string query)
        {
            using (SqlConnection sc = new SqlConnection(conn))
            {
                sc.Open();
                using (SqlCommand scmd = new SqlCommand(query, sc))
                {
                    using(SqlDataAdapter da=new SqlDataAdapter(scmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}
