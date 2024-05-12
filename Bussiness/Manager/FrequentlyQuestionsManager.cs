﻿using Bussiness.Services;
using Data.DAL;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Manager
{
    public class FrequentlyQuestionsManager : IFrequentlyQuestionService
    {
        private readonly IFrequentlyQuestionDAL _dal;

        public FrequentlyQuestionsManager(IFrequentlyQuestionDAL dal)
        {
            _dal=dal;
        }
        public void Create(FrequentlyQuestions t)
        {
            _dal.Create(t);
        }

        public void Delete(FrequentlyQuestions t)
        {
           _dal.Delete(t);
        }

        public FrequentlyQuestions GetById(int id)
        {
            return _dal.GetById(id);
        }

        public IEnumerable<FrequentlyQuestions> GetList()
        {
            return _dal.GetList();  
        }

        public void Update(FrequentlyQuestions t)
        {
            _dal.Update(t);
        }
    }
}
