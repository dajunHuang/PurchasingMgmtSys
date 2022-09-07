using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models.Entities
{
    public class Material_message
    {
        [Key]
        [Required]
        [Display(Name = "物资ID")]
        public int MID { get; set; }

        [Required]
        [Display(Name = "物资名称")]
        public string MaterialName { get; set; }

    }
}
