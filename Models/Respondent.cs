
namespace Questionnaire_API.Models;

public class Respondent
{
	public int id { get; set; }
	public string firstname { get; set; } = string.Empty;
	public string lastname { get; set; } = string.Empty;
	public char gender { get; set; }
	public sbyte age { get; set; }
	public string region { get; set; } = string.Empty;
}