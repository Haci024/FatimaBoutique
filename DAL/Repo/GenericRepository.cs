using DAL.DAL;
using DAL.DbConnection;
using Entity.Models;


namespace Data.Repositories
{

    public class GenericRepository<T> : IGenericDAL<T> where T : class
    {
        public void Create(T t)
        {
            using Context dbContext = new Context();
            dbContext.Set<T>().Add(t);
            dbContext.SaveChanges();
        }

        public void Delete(T t)
        {
            using Context dbContext = new Context();
            dbContext.Set<T>().Remove(t);
            dbContext.SaveChanges();

        }

        public T GetById(int id)
        {
            using Context dbContext = new Context();

            return  dbContext.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            using Context dbContext = new Context();

            return dbContext.Set<T>().ToList();
        }


        public void Update(T t)
        {
            using Context Context = new Context();
            
            Context.Set<T>().Update(t);
            Context.SaveChanges();

        }

    }
}

