using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessLayer
{
   public class Vehicle
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Yearr { get; set; }
        public string Model { get; set; }
        public string VIN { get; set; }
        public bool IsSelected { get; set; }
     




    }
    public class VehicleModel
    {
        public int Id { get; set; }
       
        public string Yearr { get; set; }
        public string Model { get; set; }
        public int MakerId { get; set; }
   





    }
}
