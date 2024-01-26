namespace Questionnaire_API.Models;

public class Question
{
	public int id { get; set; }
	public int surveyid { get; set; }
	public int questionnumber { get; set; }
	public string text { get; set; } = string.Empty;
	public string type { get; set; } = string.Empty;
}