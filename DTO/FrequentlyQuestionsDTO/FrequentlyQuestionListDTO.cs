using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.FrequentlyQuestionsDTO
{
    public class FrequentlyQuestionListDTO
    {
        public IEnumerable<FrequentlyQuestions> FrequentlyQuestions { get;set; }
    }
}
