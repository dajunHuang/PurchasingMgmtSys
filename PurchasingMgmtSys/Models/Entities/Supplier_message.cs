﻿using System;
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
        public int SId { get; set; }   //pk

        [Required]
        public string FactoryName { get; set; }

        [Required]
        public string Director { get; set; }

        public virtual ICollection<Supplier_material> Supplier_Materials { get; set; }
    }
}
