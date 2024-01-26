using System;
using Questionnaire_API.Data;

namespace Questionnaire_API.Services
{
    public class InterviewService : IInterviewService
    {
        private readonly AppDbContext _appDB;

        public InterviewService(AppDbContext appDB)
        {
            _appDB = appDB;
        }

        public async Task<Interview?> GetInterview(int questionId, int respondentId)
        {
            var question = _appDB.dbquestion.FirstOrDefault(p => p.id == questionId);
            if(question != null)
            {
                var survey = _appDB.dbsurvey.FirstOrDefault(p => p.id == question.surveyid);
                if(survey != null)
                {
                    var interview = _appDB.dbinterview.FirstOrDefault(p => p.respondentid == respondentId && p.surveyid == survey.id);
                    if(interview != null)
                    {
                        return interview;
                    }
                }
            }

            return null;
        }

        public async Task UpdateInterview(Interview interview)
        {
            if(interview.id == 0)
                _appDB.dbinterview.Add(interview); 
            else
            {
                var oldValue = _appDB.dbinterview.FirstOrDefault(p => p.id == interview.id);
                if(oldValue != null)
                {
                    oldValue.respondentid = oldValue.respondentid != interview.respondentid ? interview.respondentid : oldValue.respondentid;
                    oldValue.surveyid = oldValue.surveyid != interview.surveyid ? interview.surveyid : oldValue.surveyid;
                    oldValue.datetime = oldValue.datetime != interview.datetime ? interview.datetime : oldValue.datetime;
                }
            }

            await _appDB.SaveChangesAsync();
        }
    }
}

