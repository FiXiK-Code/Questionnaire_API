using System;
namespace Questionnaire_API.Models
{
	public class Interview
	{
		public int id { get; set; }
		public int surveyid { get; set; }
		public DateTime datetime { get; set; }
		public int respondentid { get; set; }
	}
}

