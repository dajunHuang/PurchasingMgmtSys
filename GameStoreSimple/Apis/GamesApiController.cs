using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStoreSimple.Controllers;
using GameStoreSimple.Helper.CustomExtension;
using GameStoreSimple.Models.DataAccess;
using GameStoreSimple.ViewModelMapper;
using GameStoreSimple.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GameStoreSimple.Apis
{
    [Route("api/games")]
    [ApiController]
    public class GamesApiController : ControllerBase
    {
        private readonly GameStoreSimpleDbContext db;
        private readonly ILogger<GamesApiController> logger;

        public GamesApiController(GameStoreSimpleDbContext db, ILogger<GamesApiController> logger)
        {
            this.db = db;
            this.logger = logger;
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