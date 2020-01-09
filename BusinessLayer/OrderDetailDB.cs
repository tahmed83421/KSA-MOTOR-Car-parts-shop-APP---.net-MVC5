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
        public void addInvoiceDetails(int CustomerID,string To_Name,string To_Phone, string Ship_Name,
            string Ship_Company,string Ship_Adress,string Ship_City,string Ship_Contact,int Vehicleid,int OrderId,string Delivary_Date,
            string Payment_Terms)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
            SqlCommand command = new SqlCommand("CreateInvoice", connection);
            command.CommandType = CommandType.StoredProcedure;


            SqlParameter parameter10 = new SqlParameter("@CustomerID", 1);
            SqlParameter parameter = new SqlParameter("@To_Name", To_Name);
            SqlParameter parameter0 = new SqlParameter("@To_Phone", To_Phone);
            SqlParameter parameter1 = new SqlParameter("@Ship_Name", Ship_Name);
            SqlParameter parameter2 = new SqlParameter("@Ship_Company", Ship_Company);
            SqlParameter parameter3 = new SqlParameter("@Ship_Adress", Ship_Adress);
            SqlParameter parameter4 = new SqlParameter("@Ship_City", Ship_City);
            SqlParameter parameter5 = new SqlParameter("@Ship_Contact", Ship_Contact);
            SqlParameter parameter6 = new SqlParameter("@Vehicle_id", Vehicleid);
            SqlParameter parameter7 = new SqlParameter("@Order_Id", OrderId);
            SqlParameter parameter8 = new SqlParameter("@Delivary_Date", Delivary_Date.ToString());
            SqlParameter parameter9 = new SqlParameter("@Payment_Terms", Payment_Terms.ToString());

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
            command.Parameters.Add(parameter10);
            connection.Open();
            command.ExecuteNonQuery();

        }
    }
}
