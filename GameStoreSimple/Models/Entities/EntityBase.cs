using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models.Entities
{
    public class EntityBase : IEntityBase
    {
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }
    }

    public interface IEntityBase
    {
        DateTime CreatedAt { get; set; }

        bool IsDeleted { get; set; }
        DateTime DeletedAt { get; set; }

    }
}
