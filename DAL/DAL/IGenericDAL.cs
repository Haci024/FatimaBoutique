using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL
{
    public interface IGenericDAL<T> where T : class
    {
        void Create(T t);
        void Update(T t);
        void Delete(T t);
        public T GetById(int id);
        public IEnumerable<T> GetList();

    }

}
