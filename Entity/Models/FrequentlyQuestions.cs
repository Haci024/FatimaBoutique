using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class FrequentlyQuestions
    {
        public int Id { get; set; }
        public bool Status { get; set; }
       //public List<FrequentlyQuestionsLanguage> FaqLanguages { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }

    //public class FrequentlyQuestionsLanguage
    //{
    //    public int Id { get; set; }
    //    public int LanguageId { get; set; }
    //    public int FaqId { get; set; }


    //    public Language Language { get; set; }
    //    public FrequentlyQuestions FrequentlyQuestions { get; set; }
    //}
}
