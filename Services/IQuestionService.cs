namespace Questionnaire_API.Services;

public interface IQuestionService
{
    Task<Question?> GetQuestion(int questionId);
    Task<Question?> GetNextQuestion(int questionId);
}