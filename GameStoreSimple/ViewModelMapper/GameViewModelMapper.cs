using MVC.Models.Entities;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.ViewModelMapper
{
    public static class GameViewModelMapper
    {
        public static GamesViewModel MapFromGameToGamesViewModel(Game game)
        {
            var gamesVM = new GamesViewModel
            {
                GameId = game.GameId,
                Name = game.Name,
                Price = game.Price,
                Genre = game.Genre.Name
            };
            return gamesVM;
        }

        public static string GetPropertyNameFromGamesViewModel(string columnIndex)
        {
            switch (columnIndex)
            {
                case "0":
                    return "GameId";
                case "1":
                    return "Name";
                case "2":
                    return "Price";
                default:
                    return "GameId";
            }

        }
    }
}
