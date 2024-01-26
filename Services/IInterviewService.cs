namespace Questionnaire_API.Services;

public interface IInterviewService
{
    Task UpdateInterview(Interview interview);
    Task<Interview?> GetInterview(int questionId, int respondentId);
}