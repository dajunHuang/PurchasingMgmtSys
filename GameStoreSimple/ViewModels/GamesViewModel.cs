using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.ViewModels
{
    public class GamesViewModel
    {
        [Display(Name = "Game Id")]
        [JsonProperty("game_id")]
        public int GameId { get; set; }

        [Display(Name = "Game Name")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Display(Name = "Price")]
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [Display(Name = "Genre")]
        [JsonProperty("genre_name")]
        public string Genre { get; set; }
    }
}
