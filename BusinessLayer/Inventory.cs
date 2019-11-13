using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;



namespace BusinessLayer
{
   public class Inventory
    {

        public IEnumerable<PartsInventory> Parts
        {
            get
            {
                List<PartsInventory> Parts = new List<PartsInventory>();
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
                SqlCommand command = new SqlCommand("spGetAllParts", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader sdr = command.ExecuteReader();
                while (sdr.Read())
                {
                    PartsInventory Part = new PartsInventory();

                    Part.ID = Convert.ToInt32(sdr["ID"]);
                    Part.Name = sdr["Name"].ToString();
                    Part.Description = sdr["Description"].ToString();
                   
                    Part.ImagePath = sdr["Picture"].ToString();

                    Part.BuyPrice = sdr["BuyPrice"].ToString();
                    Part.SalePrice = sdr["SalePrice"].ToString();
                    Part.Stock = sdr["Stock"].ToString();
                   
                    Parts.Add(Part);


                }
                return Parts;

            }
        }


        public IEnumerable<Vehicle> Vehicles
        {
            get
            {
                IList<Vehicle> Vehicless = new List<Vehicle>();
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
                SqlCommand command = new SqlCommand("spGetAllVehicle", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader sdr = command.ExecuteReader();
                while (sdr.Read())
                {
                    Vehicle vehicle = new Vehicle();

                    vehicle.Id = Convert.ToInt32(sdr["Id"]);
                    vehicle.Make = sdr["Make"].ToString();
                    vehicle.Yearr = sdr["Yearr"].ToString();

                    vehicle.Model = sdr["Model"].ToString();

                    vehicle.VIN = sdr["VIN"].ToString();
                   
                   

                    Vehicless.Add(vehicle);
                   


                }
                return Vehicless;

            }
        }

        public string GetRequests()
        {
            string req="";
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("select Stock from Parts where ID=1",connection);
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader sdr = command.ExecuteReader();
                while (sdr.Read())
                {
                    req = sdr["Stock"].ToString();
                }
            }
            return req;
        }


        public PartsInventory GetPartsById(int id)
        {
            
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("select * from tblParts where ID="+id+"", connection);
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader sdr = command.ExecuteReader();
                PartsInventory Part = new PartsInventory();
                while (sdr.Read())
                {
                    

                    Part.ID = Convert.ToInt32(sdr["ID"]);
                    Part.Name = sdr["Name"].ToString();
                    Part.Description = sdr["Description"].ToString();

                    Part.ImagePath = sdr["Picture"].ToString();
                    Part.selctedBrands = Convert.ToInt32(sdr["VehicleId"]);

                    Part.BuyPrice = sdr["BuyPrice"].ToString();
                    Part.SalePrice = sdr["SalePrice"].ToString();
                    Part.Stock = sdr["Stock"].ToString();
                    Part.Brand = sdr["Brand"].ToString();
                    Part.Approved = sdr["Approved"].ToString();

                    
                }
                return Part;
            }
         
        }




        public void AddParts(PartsInventory parts)
        {

            StringBuilder sb = new StringBuilder();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
            SqlCommand command = new SqlCommand("InsertInventory", connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter("@Name", parts.Name);
            SqlParameter parameter1 = new SqlParameter("@Description", parts.Description);
            SqlParameter parameter2 = new SqlParameter("@Picture", parts.ImagePath);
            SqlParameter parameter3 = new SqlParameter("@BuyPrice",parts.BuyPrice);
            SqlParameter parameter4 = new SqlParameter("@SalePrice", parts.SalePrice);
            SqlParameter parameter5 = new SqlParameter("@Stock", parts.Stock);
            foreach (string item in parts.SelectedVehicles)
            {
               
                sb.Append(item);
            }
            SqlParameter parameter6 = new SqlParameter("@VehicleId", sb.ToString());
            SqlParameter parameter7 = new SqlParameter("@Brand", parts.Brand);
            SqlParameter parameter8 = new SqlParameter("@Approved", parts.Approved);


            command.Parameters.Add(parameter);
            command.Parameters.Add(parameter1);
            command.Parameters.Add(parameter2);
            command.Parameters.Add(parameter3);
            command.Parameters.Add(parameter4);
            command.Parameters.Add(parameter5);
            command.Parameters.Add(parameter6);
            command.Parameters.Add(parameter7);
            command.Parameters.Add(parameter8);

            connection.Open();
            command.ExecuteNonQuery();
        }



        public void UpdateParts(PartsInventory parts)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
            SqlCommand command = new SqlCommand("UpdateParts", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter parameter0 = new SqlParameter("@ID", parts.ID);
            SqlParameter parameter = new SqlParameter("@Name", parts.Name);
            SqlParameter parameter1 = new SqlParameter("@Description", parts.Description);
            SqlParameter parameter2 = new SqlParameter("@Picture", parts.ImagePath);
            SqlParameter parameter3 = new SqlParameter("@BuyPrice", parts.BuyPrice);
            SqlParameter parameter4 = new SqlParameter("@SalePrice", parts.SalePrice);
            SqlParameter parameter5 = new SqlParameter("@Stock", parts.Stock);
            SqlParameter parameter6 = new SqlParameter("@VehicleId", 1);
            SqlParameter parameter7 = new SqlParameter("@Brand", parts.Brand);
            SqlParameter parameter8 = new SqlParameter("@Approved", parts.Approved);

            command.Parameters.Add(parameter0);
            command.Parameters.Add(parameter);
            command.Parameters.Add(parameter1);
            command.Parameters.Add(parameter2);
            command.Parameters.Add(parameter3);
            command.Parameters.Add(parameter4);
            command.Parameters.Add(parameter5);
            command.Parameters.Add(parameter6);
            command.Parameters.Add(parameter7);
            command.Parameters.Add(parameter8);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public void DeleteParts(int id)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
            SqlCommand command = new SqlCommand("DeleteParts", connection);
            command.CommandType = CommandType.StoredProcedure;


            SqlParameter parameter1 = new SqlParameter("@ID", id);


            command.Parameters.Add(parameter1);

            connection.Open();
            command.ExecuteNonQuery();

        }

  




    }
}
