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
        [Display(Name = "记录ID")]
        public int NoteId { get; set; }   //pk

        [Required]
        [Display(Name = "物资ID")]
        public Material_message MID { get; set; }

        [Required]
        [Display(Name = "供方ID")]
        public Supplier_message SID { get; set; }

        [Required]
        [Display(Name = "物资价格")]
        public decimal Price { get; set; }
    }
}
