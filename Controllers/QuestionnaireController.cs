using Microsoft.AspNetCore.Mvc;

namespace Questionnaire_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionnaireController : ControllerBase
{
    private readonly IAnswerService _answerService;
    private readonly IQuestionService _questionService;
    private readonly IResultService _resultService;
    private readonly IInterviewService _interviewService;
    private readonly ISyrveyService _syrveyService;

    public QuestionnaireController(IAnswerService answerService, IQuestionService questionService, IResultService resultService, IInterviewService interviewService, ISyrveyService syrveyService)
    {
        _answerService = answerService;
        _questionService = questionService;
        _resultService = resultService;
        _interviewService = interviewService;
        _syrveyService = syrveyService;
    }

    [HttpGet("{questionId}")]
    public async Task<ActionResult> GetQuestion(int questionId)
    {
        var question = await _questionService.GetQuestion(questionId);
        if (question == null) return NotFound("Question not found");
        var answer = await _answerService.GetAnswers(questionId);

        var output = new
        {
            numberQuestion = question.questionnumber,
            text = question.text,
            typeAnswer = question.type,
            answers = answer.Select(p => p.text)
        };

        return Ok(output);
    }

    [HttpPost]
    public async Task<ActionResult> SendAnswer([FromBody] AnswerPostParam answer)
    {
        var interview = await _interviewService.GetInterview(answer.QuestionId, answer.RespondentId);
        if(interview == null)
        {
            var surey = await _syrveyService.GetSurvey(answer.QuestionId);
            if (surey == null) return NotFound("Surey not found");

            interview = new Interview
            {
                respondentid = answer.RespondentId,
                surveyid = surey.id,
                datetime = DateTime.Now
            };
            await _interviewService.UpdateInterview(interview);
        } 

        var result = new Result
        {
             ansver = string.Join(", ", answer.Answers),
             interviewid = interview.id,
             questionid = answer.QuestionId,
             respondentid = answer.RespondentId
        };
        await _resultService.UpdateResult(result);

        return Ok(await _questionService.GetNextQuestion(answer.QuestionId));
    }
}


