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
       
        [Range (24, 96)]
        public int Width { get; set; }
        [Range(12, 48)]
        public int Depth { get; set; }
        public string Material { get; set; }
        [Range(0, 7)]
        public int Drawers { get; set; }
        public int Order { get; set; }
        [Display(Name = "Date Order")]
        [DataType(DataType.Date)]
        public DateTime DateOrder { get; set; }
        
        public int Price { get; set; }
        
         
    }
   
   

}
