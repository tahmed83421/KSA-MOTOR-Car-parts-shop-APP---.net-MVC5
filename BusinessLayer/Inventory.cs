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



                    Part.PartID = Convert.ToInt32(sdr["PartID"]);
                    Part.CarMfgID = sdr["CarMfgID"].ToString();
                    Part.Name = sdr["Name"].ToString();
                    Part.ImagePath = sdr["Picture"].ToString();
                    Part.Description = sdr["Description"].ToString();
                    Part.Brand = sdr["Brand"].ToString();
                    Part.Fitment = sdr["Fitment"].ToString();
                    string[] tokens = sdr["Vehicle"].ToString().Split(',');
                    Part.selctedCarBrands = GetVehicleById(tokens);
                    
                    Part.CostPrice = sdr["CostPrice"].ToString();
                    Part.SalePrice = sdr["SalePrice"].ToString();
                    DateTime EntryDate = Convert.ToDateTime(sdr["EntryDate"].ToString());
                    TimeSpan t = System.DateTime.Now.Subtract(EntryDate);
                    Part.Age = t.Days.ToString() + "Days" + t.Hours.ToString()+"Hours";

                    Part.Qty = sdr["Qty"].ToString();
                    Part.VModelId = Convert.ToInt32(sdr["VModelId"]);
               

                    Part.Approved = Convert.ToBoolean(sdr["Approved"]);


                    Parts.Add(Part);


                }
                return Parts;

            }
        }



        public string GetVehicleById(string[] Ids)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString))
            {
                StringBuilder sb = new StringBuilder();
                foreach (string item in Ids)
                {
                   

                    SqlCommand command = new SqlCommand("select * from Vehicle where Id=" + Convert.ToInt32(item) + "", connection);
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader sdr = command.ExecuteReader();
                   
                    Vehicle vehicle = new Vehicle();
                    while (sdr.Read())
                    {




                        vehicle.Id = Convert.ToInt32(sdr["Id"]);
                        vehicle.Make = sdr["Make"].ToString();
                        vehicle.Yearr = sdr["Yearr"].ToString();

                        vehicle.Model = sdr["Model"].ToString();

                        vehicle.VIN = sdr["VIN"].ToString();


                        sb.Append(sdr["Make"].ToString());
                        string.Join(",", sb);
                    }
                    connection.Close();
                  
                }
                return sb.ToString();
             
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

        public IEnumerable<VehicleModel> VModels
        {
            get
            {
                IList<VehicleModel> Vehicless = new List<VehicleModel>();
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
                SqlCommand command = new SqlCommand("Select * from VehicleModel", connection);
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader sdr = command.ExecuteReader();
                while (sdr.Read())
                {
                    VehicleModel vehicle = new VehicleModel();

                    vehicle.Id = Convert.ToInt32(sdr["Id"]);
               
                    vehicle.Yearr = sdr["Yearr"].ToString();

                    vehicle.Model = sdr["Model"].ToString();

                    vehicle.MakerId = Convert.ToInt32(sdr["MakerId"]);



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
                SqlCommand command = new SqlCommand("select * from VehicleParts where PartID=" + id+"", connection);
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader sdr = command.ExecuteReader();
                PartsInventory Part = new PartsInventory();
                while (sdr.Read())
                {




                    Part.PartID = Convert.ToInt32(sdr["PartID"]);
                    Part.CarMfgID = sdr["CarMfgID"].ToString();
                    Part.Name = sdr["Name"].ToString();
                    Part.ImagePath = sdr["Picture"].ToString();
                    Part.Description = sdr["Description"].ToString();
                    Part.Brand = sdr["Brand"].ToString();
                    Part.Fitment = sdr["Fitment"].ToString();
                    string[] tokens = sdr["Vehicle"].ToString().Split(',');
                    Part.selctedCarBrands = GetVehicleById(tokens);

                   

                    Part.CostPrice = sdr["CostPrice"].ToString();
                    Part.SalePrice = sdr["SalePrice"].ToString();
                    Part.Age = sdr["EntryDate"].ToString();
                    Part.Qty = sdr["Qty"].ToString();
                 

                    Part.Approved = Convert.ToBoolean(sdr["Approved"]);

                    
                }
                return Part;
            }
         
        }

        public string GetEmailAddressByRole(string Role)
        {
            string Email = "";
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("select Email from Users where Role='"+Role+"'", connection);
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader sdr = command.ExecuteReader();
                while (sdr.Read())
                {
                  Email = sdr["Email"].ToString();
                }
            }
            return Email;

        }


        public void SetQuotationStatus(string status,int Id)
        {
           
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("Update quotation set Status ='" + status + "' where Id ="+Id+"", connection);
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteReader();
                connection.Close();
               
            }
         

        }

        public bool updateComment(string Cmnt, int ID)
        {

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("Update MarketAnalyze set Comment ='" + Cmnt + "' where ID ="+ID+"", connection);
                command.CommandType = CommandType.Text;
                connection.Open();
                try
                {
                    command.ExecuteReader();
                    return true;
                }
                catch
                {
                    return false;
                }
              

            }


        }




        public void AddOrder(PartsInventory parts)
        {
            
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
            SqlCommand command = new SqlCommand("InsertOrder", connection);
            command.CommandType = CommandType.StoredProcedure;



            SqlParameter parameter = new SqlParameter("@Description", parts.CarMfgID);
            SqlParameter parameter0 = new SqlParameter("@PartsId", parts.Name);
            SqlParameter parameter2 = new SqlParameter("@ProductQuantity", parts.ImagePath);
            SqlParameter parameter1 = new SqlParameter("@DeliveryStatus", parts.Description);
            SqlParameter parameter7 = new SqlParameter("@Comment", parts.Brand);
         
            SqlParameter parameter8 = new SqlParameter("@Approved", parts.Approved);
            command.Parameters.Add(parameter);
            command.Parameters.Add(parameter0);
            command.Parameters.Add(parameter1);
            command.Parameters.Add(parameter2);  
            command.Parameters.Add(parameter7);
            command.Parameters.Add(parameter8);
         
            connection.Open();
            command.ExecuteNonQuery();
        }





        public void AddParts(PartsInventory parts)
        {
            int c = 0;
            StringBuilder sb = new StringBuilder();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
            SqlCommand command = new SqlCommand("InsertInventory", connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter("@CarMfgID", parts.CarMfgID);
            SqlParameter parameter0 = new SqlParameter("@Name", parts.Name);
            SqlParameter parameter2 = new SqlParameter("@Picture", parts.ImagePath);
            SqlParameter parameter1 = new SqlParameter("@Description", parts.Description);
            SqlParameter parameter7 = new SqlParameter("@Brand", parts.Brand);
            SqlParameter parameter9 = new SqlParameter("@Fitment", parts.Fitment);
          
            foreach (string item in parts.SelectedVehicles)
            {
                if (c != 0) { sb.Append(","); }
               
                sb.Append(item);
                c++;
               
            }
            SqlParameter parameter6 = new SqlParameter("@Vehicle", sb.ToString());
            SqlParameter parameter3 = new SqlParameter("@CostPrice",parts.CostPrice);
            SqlParameter parameter4 = new SqlParameter("@SalePrice", parts.SalePrice);
            SqlParameter parameter5 = new SqlParameter("@Qty", parts.Qty);
      
           
           
            SqlParameter parameter8 = new SqlParameter("@Approved", parts.Approved);


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

            connection.Open();
            command.ExecuteNonQuery();
        }



        public void UpdateParts(PartsInventory parts)
        {
            int c = 0;
            StringBuilder sb = new StringBuilder();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
            SqlCommand command = new SqlCommand("UpdateParts", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter parameterr = new SqlParameter("@PartID", parts.PartID);
            SqlParameter parameter = new SqlParameter("@CarMfgID", parts.CarMfgID);
            SqlParameter parameter0 = new SqlParameter("@Name", parts.Name);
            SqlParameter parameter2 = new SqlParameter("@Picture", parts.ImagePath);
            SqlParameter parameter1 = new SqlParameter("@Description", parts.Description);
            SqlParameter parameter7 = new SqlParameter("@Brand", parts.Brand);
            SqlParameter parameter9 = new SqlParameter("@Fitment", parts.Fitment);

            foreach (string item in parts.SelectedVehicles)
            {
                if (c != 0) { sb.Append(","); }

                sb.Append(item);
                c++;

            }
            SqlParameter parameter6 = new SqlParameter("@Vehicle", sb.ToString());
            SqlParameter parameter3 = new SqlParameter("@CostPrice", parts.CostPrice);
            SqlParameter parameter4 = new SqlParameter("@SalePrice", parts.SalePrice);
            SqlParameter parameter5 = new SqlParameter("@Qty", parts.Qty);



            SqlParameter parameter8 = new SqlParameter("@Approved", parts.Approved);


            command.Parameters.Add(parameterr);
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

            connection.Open();
            command.ExecuteNonQuery();
        }

        public void DeleteParts(int id)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
            SqlCommand command = new SqlCommand("DeleteParts", connection);
            command.CommandType = CommandType.StoredProcedure;


            SqlParameter parameter1 = new SqlParameter("@PartID", id);


            command.Parameters.Add(parameter1);

            connection.Open();
            command.ExecuteNonQuery();

        }

  




    }
}
