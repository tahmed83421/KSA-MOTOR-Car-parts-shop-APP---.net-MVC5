using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
   public  class Order
    {
        
        int ID { get; set; }
        string Description { get; set; }
        int PartsId { get; set; }
        string ProductQuantity { get; set; }
        string DeliveryStatus { get; set; }
        string Comment { get; set; }
        string Approved { get; set; }




    }
}
