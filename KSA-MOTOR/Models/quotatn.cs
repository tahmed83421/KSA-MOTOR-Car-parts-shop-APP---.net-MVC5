using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KSA_MOTOR.Models
{
    [MetadataType(typeof(QuotationMetaData))]
    public partial class quotation
    {

    }

    public class QuotationMetaData
    {
       [Display(Name = "Parts Picture")]
       public string PPicture { get; set; }
        [Display(Name ="Vehicle Picture")]
        public string VPicture { get; set; }
        public string Status { get; set; }
    }


}