using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lullo.Models
{
    [Table("groceries")]
    public class Groceries
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}