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
        int PartID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
       HttpPostedFileBase Picture { get; set; }
       
      

    }

    public class PartsInventory : IEParts
    {



        public int PartID { get; set; }
        [Display(Name ="Car Mfg No:")]
        public string CarMfgID { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Image")]
        [Required(ErrorMessage = "Please choose file to upload.")]
        public HttpPostedFileBase Picture { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Fitment { get; set; }

        public string CostPrice {get;set;}
        public string SalePrice { get; set; }
        [Display(Name ="Quantity")]
        public string Qty { get; set; }
        public string Age { get; set; }
        [Required]
        [Display(Name = "Vehicle")]
        public string[] SelectedVehicles { get; set; }
        public string selctedCarModel { get; set; }
        public string selctedCarBrands { get; set; }
        public List<Vehicle> GetVehivclesList { get; set; }
        public int selectedYear { get; set; } 
        public int VModelId { get; set; }
        public List<VehicleModel> GetModelList { get; set; }
        public bool Approved { get; set; }
        public int Qtyy { get; set; }


    }

}
