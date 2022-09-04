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
        public int MID { get; set; }

        [Required]
        public int NowNumber { get; set; }
    }
}
