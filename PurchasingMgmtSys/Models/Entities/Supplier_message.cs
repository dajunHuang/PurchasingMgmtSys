using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models.Entities
{
    public class Supplier_message
    {
        [Key]
        [Required]
        [Display(Name = "供方ID")]
        public int SId { get; set; }   //pk

        [Required]
        [Display(Name = "厂家名称")]
        public string FactoryName { get; set; }

        [Required]
        [Display(Name = "负责人")]
        public string Director { get; set; }

        public virtual ICollection<Record> Record { get; set; }
    }
}
