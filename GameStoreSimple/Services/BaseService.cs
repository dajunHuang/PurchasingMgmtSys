using GameStoreSimple.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStoreSimple.Services
{
    public abstract class BaseService
    {
        protected GameStoreSimpleDbContext db;

        public BaseService()
        {
            db = new GameStoreSimpleDbContext();
        }

        public BaseService(GameStoreSimpleDbContext dBContext)
        {
            db = dBContext ?? new GameStoreSimpleDbContext();
        }

    }
}
