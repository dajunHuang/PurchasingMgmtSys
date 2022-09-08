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
        public int MID { get; set; }

        [Required]
        public string MaterialName { get; set; }
        public virtual ICollection<Record> Record { get; set; }
    }
}
