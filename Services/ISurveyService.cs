using System;
namespace Questionnaire_API.Services
{
	public interface ISurveyService
	{
		Task<Survey?> GetSurvey(int questionId);
	}
}

