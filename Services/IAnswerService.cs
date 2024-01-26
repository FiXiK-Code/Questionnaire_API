namespace Questionnaire_API.Services;

public interface IAnswerService
{
	Task<List<Answer>> GetAnswers(int questionId);
}