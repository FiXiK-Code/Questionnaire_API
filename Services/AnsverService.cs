namespace Questionnaire_API.Services;

public class AnsverService : IAnswerService
{
    private readonly AppDbContext _appDB;

    public AnsverService(AppDbContext appDB)
    {
        _appDB = appDB;
    }

    public async Task<List<Answer>> GetAnswers(int questionId)
    {
        return _appDB.dbanswer.Where(p => p.id == questionId).ToList();
    }
}