using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models.Entities
{
    public class Game
    {
        public int GameId { get; set; }   //pk

        [Required]
        [MaxLength(50)]
        [Display(Name = "Game Name")]
        public string Name { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }
    }
}
