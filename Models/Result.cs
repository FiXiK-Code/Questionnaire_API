﻿namespace Questionnaire_API.Models;

public class Result
{
	public int id { get; set; }
	public int questionid { get; set; }
	public string ansver { get; set; } = string.Empty;
	public int respondentid { get; set; }
	public int interviewid { get; set; }
}