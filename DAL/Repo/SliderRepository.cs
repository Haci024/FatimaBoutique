using DAL.DbConnection;
using Data.DAL;
using Data.Repositories;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repo
{
    public class SliderRepository:GenericRepository<Slider>,ISliderDAL
    {
        private readonly Context _db;

        public SliderRepository(Context db)
        {
            _db = db;
        }
        
    }
}
