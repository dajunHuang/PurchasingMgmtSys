using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models.Entities
{
    public class Genre : EntityBase
    {
        public int GenreId { get; set; }

        [Display(Name = "Genre Name")]
        public string Name { get; set; }

        //navigation property
        public ICollection<Game> Games { get; set; }
    }
}
