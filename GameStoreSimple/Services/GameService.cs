using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.Models.DataAccess;

namespace MVC.Services
{
    public class GameService : BaseService, IGameService
    {
        public GameService() : base()
        {

        }

        public GameService(ApplicationDbContext dBContext) : base(dBContext)
        {

        }      
        

        public async Task<bool> CreateGameAsync()
        {
            return true;
        }
    }
}
