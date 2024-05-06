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
    public class FrequentlyQuestionRepository : GenericRepository<FrequentlyQuestions>, IFrequentlyQuestionDAL
    {
        private readonly Context _context;

        public FrequentlyQuestionRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<FrequentlyQuestions> ActiveFaqList()
        {
            return _context.FrequentlyQuestions.Where(x => x.Status==false).ToList();
        }

        public IEnumerable<FrequentlyQuestions> DeactiveFaqList()
        {
            return _context.FrequentlyQuestions.Where(x => x.Status==true).ToList();
        }
    }
}
