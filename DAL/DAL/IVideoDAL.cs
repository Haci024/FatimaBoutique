using DAL.DAL;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL
{
    public interface IVideoDAL:IGenericDAL<Videos>
    {
        public List<Videos> GetActiveVideoList();

        public List<Videos> DeactiveVideoList();


    }

}
