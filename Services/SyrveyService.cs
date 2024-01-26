using System;
using Questionnaire_API.Data;
using Questionnaire_API.Models;

namespace Questionnaire_API.Services
{
	public class SyrveyService : ISyrveyService
    {
        private readonly AppDbContext _appDB;

        public SyrveyService(AppDbContext appDB)
        {
            _appDB = appDB;
        }

        public async Task<Survey?> GetSurvey(int questionId)
        {
            var question = _appDB.dbquestion.FirstOrDefault(p => p.id == questionId);
            if (question != null)
            {
                return _appDB.dbsurvey.FirstOrDefault(p => p.id == question.surveyid);
            }

            return null;
        }
    }
}

