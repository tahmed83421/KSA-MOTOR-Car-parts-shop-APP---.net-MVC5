using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSA_MOTOR.Models
{
    public class MyViewModel
    {
        public quotation quotationss { get; set; }
         public MarketAnalyze marketAnalyze { get; set; }
        public List<MarketAnalyze> marketAnalyzes { get; set; }
    }
}