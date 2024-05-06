using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.FrequentlyQuestionsDTO
{
    public class AddQuestionDTO
    {
        public List<AddQuestionLanguageDTO> Languages {  get; set; }
    }

    public class AddQuestionLanguageDTO
    {
        public int LanguageId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
