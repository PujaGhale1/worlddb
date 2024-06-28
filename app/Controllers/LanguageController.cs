using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class LanguagePopulationInfo
{
    public required string Language { get; set; }
    public int NumberOfSpeakers { get; set; }
    public decimal PercentageOfWorldPopulation { get; set; }
}

[Route("api/data/language/")]
[ApiController]
public class LanguageController : ControllerBase
{
    private readonly AppDbContext _context;

    public LanguageController(AppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    [HttpGet("")]
    public IActionResult GetLanguageStatistics()
    {
        var languagePopulations = new List<LanguagePopulationInfo>();

        decimal totalWorldPopulation = _context.Countries.Sum(c => c.Population);

        var languages = new List<string> { "Chinese", "English", "Hindi", "Spanish", "Arabic" };

        foreach (var language in languages)
        {
            var languagePopulation = _context.CountryLanguages
                .Where(cl => cl.Language == language )
                .Join(_context.Countries, cl => cl.CountryCode, c => c.Code, (cl, c) => new { cl, c })
                .Sum(join => join.cl.Percentage * join.c.Population / 100);

            decimal percentageOfWorldPopulation = (languagePopulation / totalWorldPopulation) * 100;

            languagePopulations.Add(new LanguagePopulationInfo
                {
                    Language = language,
                    NumberOfSpeakers = (int)Math.Round(languagePopulation),
                    PercentageOfWorldPopulation = percentageOfWorldPopulation
                });
        }

        languagePopulations = languagePopulations.OrderByDescending(lp => lp.NumberOfSpeakers).ToList();


        return Ok(languagePopulations);
    }

}