using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GameStoreSimple.Models.Entities
{
    public class PlayerGame : EntityBase
    {
        [Key]
        public int PlayerId { get; set; }   //pk
        [Key]
        public int GameId { get; set; }   //pk

        //navigation property
        public Player Player { get; set; }
        public Game Game { get; set; }


    }
}
