using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace BusinessLayer
{
   public class Inventory
    {

        public IEnumerable<PartsInventory> Parts
        {
            get
            {
                IList<PartsInventory> Parts = new List<PartsInventory>();
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
                    Part.Picture = sdr["Picture"].ToString();
                    Part.VehicleId = 1;
                    Parts.Add(Part);


                }
                return Parts;

            }
        }


    }
}
