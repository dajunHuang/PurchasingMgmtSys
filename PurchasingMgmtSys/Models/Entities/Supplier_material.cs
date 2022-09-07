using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models.Entities
{
    public class Supplier_material
    {
        [Key]
        [Required]
        public int NoteId { get; set; }   //pk

        [Required]
        public Material_message MID { get; set; }

        [Required]
        public Supplier_message SID { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
