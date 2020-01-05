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
    public class CreateInvoice
    {
        public void addInvoiceDetails()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
            SqlCommand command = new SqlCommand("CreateInvoice", connection);
            command.CommandType = CommandType.StoredProcedure;



            SqlParameter parameter = new SqlParameter("@To_Name", "testdescriptoin");
            SqlParameter parameter0 = new SqlParameter("@To_Phone", "0809897");
            SqlParameter parameter1 = new SqlParameter("@Ship_Name", "TT");
            SqlParameter parameter2 = new SqlParameter("@Ship_Company", "Not Delivered");
            SqlParameter parameter3 = new SqlParameter("@Ship_Adress", "Not Delivered");
            SqlParameter parameter4 = new SqlParameter("@Ship_City", "Not Delivered");
            SqlParameter parameter5 = new SqlParameter("@Ship_Contact", "Not Delivered");
            SqlParameter parameter6 = new SqlParameter("@Vehicle_Id", "Not Delivered");
            SqlParameter parameter7 = new SqlParameter("@Order_Id", "Not Delivered");
            SqlParameter parameter8 = new SqlParameter("@Delivary_Date", "Not Delivered");
            SqlParameter parameter9 = new SqlParameter("@Payment_Terms", "Not Delivered");

            command.Parameters.Add(parameter);
            command.Parameters.Add(parameter0);
            command.Parameters.Add(parameter1);
            command.Parameters.Add(parameter2);
            command.Parameters.Add(parameter3);
            command.Parameters.Add(parameter4);
            command.Parameters.Add(parameter5);
            command.Parameters.Add(parameter6);
            command.Parameters.Add(parameter7);
            command.Parameters.Add(parameter8);
            command.Parameters.Add(parameter9);

        }
    }
}
