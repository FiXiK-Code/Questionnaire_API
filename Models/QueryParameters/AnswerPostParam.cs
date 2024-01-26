namespace Questionnaire_API.Models;

public class AnswerPostParam
{
	public string[] Answers { get; set; } = new string[] { };
	public int QuestionId { get; set; }
	public int RespondentId { get; set; }
}