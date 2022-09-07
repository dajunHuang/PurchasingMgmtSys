using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models.Entities
{
    public class Warehouse_material
    {
        [Key]
        [Required]
        public int WID { get; set; }

        [Required]
        [Display(Name = "物资")]
        public Material_message Material_message { get; set; }

        [Required]
        [Display(Name = "物资数量")]
        public int NowNumber { get; set; }

        public string MaterialName()
        {
            return Material_message.MaterialName;
        }
    }
}
