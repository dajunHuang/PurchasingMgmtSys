using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Models.DataAccess;
using MVC.Models.Entities;
using Microsoft.AspNetCore.Authorization;

namespace MVC.Controllers
{
    [Authorize]
    public class GamesController : Controller
    {
        // GET: Games
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
