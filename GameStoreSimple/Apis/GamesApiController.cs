using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.Controllers;
using MVC.Helper.CustomExtension;
using MVC.Models.DataAccess;
using MVC.ViewModelMapper;
using MVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MVC.Apis
{
    [Route("api/games")]
    [ApiController]
    public class GamesApiController : ControllerBase
    {
        private readonly GameStoreSimpleDbContext db;

        public GamesApiController(GameStoreSimpleDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int draw)
        {
            var totalGames = db.Games.Include(g => g.Genre).AsNoTracking();

            var totalGamesCount = totalGames.Count();
            var filteredGamesCount = totalGamesCount;

            var query = Request.Query;
            var pagingGames = totalGames.Paginate(query, GameViewModelMapper.GetPropertyNameFromGamesViewModel).AsNoTracking();

            List<GamesViewModel> gamesVMs = new List<GamesViewModel>();
            foreach (var game in await pagingGames.ToListAsync())
            {
                var gamesVM = GameViewModelMapper.MapFromGameToGamesViewModel(game);
                gamesVMs.Add(gamesVM);
            }

            dynamic response = new
            {
                Data = gamesVMs,
                Draw = draw.ToString(),
                RecordsTotal = totalGamesCount,
                RecordsFiltered = totalGamesCount
            };
            return Ok(response);
        }
    }
}