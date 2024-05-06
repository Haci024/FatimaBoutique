using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.FrequentlyQuestionsDTO
{
    public class UpdateQuestionDTO
    {
        public int Id { get; set; }
        public List<AddQuestionLanguageDTO> Languages { get; set; }
    }
}
