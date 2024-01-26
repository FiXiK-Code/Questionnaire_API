using System;
using Questionnaire_API.Data;

namespace Questionnaire_API.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly AppDbContext _appDB;

        public QuestionService(AppDbContext appDB)
        {
            _appDB = appDB;
        }

        public async Task<Question?> GetNextQuestion(int questionId)
        {
            var previousQuestion = _appDB.dbquestion.FirstOrDefault(p => p.id == questionId);
            if(previousQuestion != null)
            {
                return _appDB.dbquestion.FirstOrDefault(p => p.questionnumber == previousQuestion.questionnumber + 1);
            }
            return null;
        }

        public async Task<Question?> GetQuestion(int questionId)
        {
            return _appDB.dbquestion.FirstOrDefault(p => p.id == questionId);
        }
    }
}

