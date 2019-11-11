using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web.Mvc;

namespace BusinessLayer
{


    public interface IEParts
    {
        int ID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
       HttpPostedFileBase Picture { get; set; }
       
      

    }

    public class PartsInventory : IEParts
    {


        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Upload)]
        [Display(Name = "Upload Picture")]
        [Required(ErrorMessage = "Please choose file to upload.")]
        public HttpPostedFileBase Picture { get; set; }
        public string ImagePath { get; set; }
       
        public string BuyPrice {get;set;}
        public string SalePrice { get; set; }
        public string Stock { get; set; }
        [Required]
        [Display(Name = "Vehicle")]
        public string SelectedVehicles { get; set; }
        public IEnumerable<SelectListItem> Vehivcles { get; set; }
        public string Brand { get; set; }
        public string Approved { get; set; }


    }

}
