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
        [Display(Name = "仓库记录ID")]
        public int WID { get; set; }

        [Required]
        [Display(Name = "物资ID")]
        public Material_message MID { get; set; }

        [Required]
        [Display(Name = "物资数量")]
        public int NowNumber { get; set; }
    }
}
