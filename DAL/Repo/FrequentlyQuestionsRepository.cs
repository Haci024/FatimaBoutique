using DAL.DbConnection;
using Data.DAL;
using Data.Repositories;
using DTO.FrequentlyQuestionsDTO;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<FaqListDTO>> ActiveFaqList()
        {
            IEnumerable<FaqListDTO> data= await _context.FrequentlyQuestions.Where(x => x.Status == true).Select(x=> new FaqListDTO{ 
            Id = x.Id,
            Answer=x.Answer,
            Question=x.Question,
            }).ToListAsync();
            return data;
        }

        public async Task<IEnumerable<FaqListDTO>> DeactiveFaqList()
        {
            IEnumerable<FaqListDTO> data = await _context.FrequentlyQuestions.Where(x => x.Status == false).Select(x => new FaqListDTO
            {
                Id = x.Id,
                Answer = x.Answer,
                Question = x.Question,
            }).ToListAsync();
            return data;
        }

    
    }
}
