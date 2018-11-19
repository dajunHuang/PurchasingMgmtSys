using GameStoreSimple.Models.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStoreSimple.Controllers
{
    public class BaseController : Controller
    {
        protected GameStoreSimpleDbContext db = new GameStoreSimpleDbContext();        
    }
}
