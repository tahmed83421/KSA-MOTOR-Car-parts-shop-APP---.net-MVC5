using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BusinessLayer
{
    public class LoginCheck
    {


        public bool  LoginAuthorization(string Password)
        {

          
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
            SqlDataAdapter ad = new SqlDataAdapter("SELECT COUNT(*) from Administration where Password = '" + Password.Trim() + "' ", connection);
            DataTable dt = new DataTable();

            ad.Fill(dt);


            if (dt.Rows[0][0].ToString() == "1")
            {
                return true;

            }
            else
            {
                return false;
            }

          

        }

       


    }
}
