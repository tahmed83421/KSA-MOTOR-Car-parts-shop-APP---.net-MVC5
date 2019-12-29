using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
   public  class Order
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public Nullable<int> PartsId { get; set; }
        public string ProductQuantity { get; set; }
        public string DeliveryStatus { get; set; }
        public string Comment { get; set; }
        public string Approved { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public string Unit_Price { get; set; }

       
      




    }
}
