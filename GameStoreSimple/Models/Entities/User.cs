using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}
