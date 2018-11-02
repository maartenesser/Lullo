using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Lullo.Models
{
    [Table("EatAtHome")]

    public class EatAtHome
    {
        [Key]
        public int Id { get; set; }

        public Boolean EatsAtHome { get; set; }
        public int Guests { get; set; }
    }
}