namespace Questionnaire_API.Models;

public class Answer
{
    public int id { get; set; }
    public int quesitonId { get; set; }
    public string text { get; set; } = string.Empty;
}