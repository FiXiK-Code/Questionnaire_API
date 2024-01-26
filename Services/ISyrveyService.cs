using System;
namespace Questionnaire_API.Services
{
	public interface ISyrveyService
	{
		Task<Survey?> GetSurvey(int questionId);
	}
}

