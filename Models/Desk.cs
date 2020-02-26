using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace MegaDesk_RazorPages.Models
{
    public class Desk
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }
        public string Material { get; set; }
        public int Drawers { get; set; }
        public int Order { get; set; }
        [Display(Name = "Date Order")]
        [DataType(DataType.Date)]
        public DateTime DateOrder { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }
    }
}
