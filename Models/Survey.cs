using System;
namespace Questionnaire_API.Models
{
	public class Survey
	{
		public int id { get; set; }
		public string name { get; set; } = string.Empty;
		public string description { get; set; } = string.Empty;
		public Int16 countquestions { get; set; }
		public string type { get; set; } = string.Empty;
		public string category { get; set; } = string.Empty;
		public DateTime datecreation { get; set; } = new DateTime(1, 1, 1);
		public DateTime enddate { get; set; } = new DateTime(1, 1, 1);
    }
}

