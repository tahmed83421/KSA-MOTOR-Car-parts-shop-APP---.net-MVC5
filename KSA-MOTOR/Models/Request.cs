using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSA_MOTOR.Models
{
    [Table("Administration")]
    public class Administrations
    {
        public int Password { get; set; }
    }
}