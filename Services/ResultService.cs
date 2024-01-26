using System;
using Questionnaire_API.Data;
using Questionnaire_API.Models;

namespace Questionnaire_API.Services
{
    public class ResultService : IResultService
    {
        private readonly AppDbContext _appDB;

        public ResultService(AppDbContext appDB)
        {
            _appDB = appDB;
        }

        public async Task UpdateResult(Result result)
        {
            if (result.id == 0)
                _appDB.dbresult.Add(result);
            else
            {
                var oldValue = _appDB.dbresult.FirstOrDefault(p => p.id == result.id);
                if (oldValue != null)
                {
                    oldValue.questionid = oldValue.questionid != result.questionid ? result.questionid : oldValue.questionid;
                    oldValue.ansver = oldValue.ansver != result.ansver ? result.ansver : oldValue.ansver;
                    oldValue.respondentid = oldValue.respondentid != result.respondentid ? result.respondentid : oldValue.respondentid;
                    oldValue.interviewid = oldValue.interviewid != result.interviewid ? result.interviewid : oldValue.interviewid;
                }
            }

            await _appDB.SaveChangesAsync();
        }
    }
}

