using MVC.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Services
{
    public abstract class BaseService
    {
        protected ApplicationDbContext db;

        public BaseService()
        {
            db = new ApplicationDbContext();
        }

        public BaseService(ApplicationDbContext dBContext)
        {
            db = dBContext ?? new ApplicationDbContext();
        }

    }
}
