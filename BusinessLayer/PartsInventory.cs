using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace BusinessLayer
{


    public interface IEParts
    {
        int ID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Picture { get; set; }
       
        int VehicleId { get; set; }

    }
   
       public class PartsInventory: IEParts
    {

        
       public int ID { get; set; }
       public string Name { get; set; }
       public string Description { get; set; }
       public string Picture { get; set; }

       public int VehicleId { get; set; }

    }
}
