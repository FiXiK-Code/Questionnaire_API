using Microsoft.EntityFrameworkCore;

namespace Questionnaire_API.Data;

public class AppDbContext : DbContext
{
    protected readonly IConfiguration Configuration;


    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql(Configuration.GetConnectionString("QuestionnaireDataBase"));

    }

    public DbSet<Answer> dbanswer { get; set; }
    public DbSet<Interview> dbinterview { get; set; }
    public DbSet<Question> dbquestion { get; set; }
    public DbSet<Respondent> dbrespondent { get; set; }
    public DbSet<Result> dbresult { get; set; }
    public DbSet<Survey> dbsurvey { get; set; }

}