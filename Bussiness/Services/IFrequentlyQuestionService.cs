using DTO.FrequentlyQuestionsDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services
{
    public interface IFrequentlyQuestionService:IGenericService<FrequentlyQuestions>
    {
        Task<IEnumerable<FaqListDTO>> ActiveFaqList();

        Task<IEnumerable<FaqListDTO>> DeactiveFaqList();


    }
}
