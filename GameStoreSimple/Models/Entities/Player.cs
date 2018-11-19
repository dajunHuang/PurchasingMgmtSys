using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GameStoreSimple.Models.Entities
{
    public class Player : EntityBase
    {
        public int PlayerId { get; set; }

        public string Name { get; set; }

        public string UserId { get; set; }    //fk

        //navigation property
        public ApplicationUser User { get; set; }
    }
}
