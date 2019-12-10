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
    public class OrderDetailDB
    {
        public void AddOrder(int id,int qty)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
            SqlCommand command = new SqlCommand("InsertOrder", connection);
            command.CommandType = CommandType.StoredProcedure;
            Order order1 = new Order();

            SqlParameter parameter = new SqlParameter("@Description","testdescriptoin" );
            SqlParameter parameter0 = new SqlParameter("@PartsId", id); 
            SqlParameter parameter1 = new SqlParameter("@ProductQuantity",qty); 
            SqlParameter parameter2 = new SqlParameter("@DeliveryStatus", "Not Delivered");
            SqlParameter parameter3 = new SqlParameter("@Comment", "Not Delivered"); 
            SqlParameter parameter4 = new SqlParameter("@Approved", "Not Delivered");

            command.Parameters.Add(parameter);
            command.Parameters.Add(parameter0);
            command.Parameters.Add(parameter1);
            command.Parameters.Add(parameter2);
            command.Parameters.Add(parameter3);
            command.Parameters.Add(parameter4);


            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
