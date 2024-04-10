using DAL.DAL;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL
{
    public interface ISliderDAL:IGenericDAL<Slider>
    {
        public List<Slider> ActiveSliderList();

        public List<Slider> DeactiveSliderList();

        
    }
}
