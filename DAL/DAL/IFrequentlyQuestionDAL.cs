using DAL.DAL;
using DTO.FrequentlyQuestionsDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL
{
    public interface IFrequentlyQuestionDAL:IGenericDAL<FrequentlyQuestions>
    {
         Task<IEnumerable<FaqListDTO>> ActiveFaqList();

         Task<IEnumerable<FaqListDTO>> DeactiveFaqList();
    }
}
