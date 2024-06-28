using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class PopulationSummary
{
    public string? Continent { get; set; }
    public string? Region { get; set; }
    public string? Country { get; set; }
    public long PopulationInCities { get; set; }
    public long PopulationNotInCities { get; set; }
}

[Route("api/data/population/")]
[ApiController]
public class DataAccessController : ControllerBase
{
    private readonly AppDbContext _context;

    public DataAccessController(AppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    [HttpGet("world")]
    public IActionResult GetWorldPopulation()
    {
        decimal worldPopulation = _context.Countries
            .Sum(c => c.Population);
        return Ok(worldPopulation);
    }

    [HttpGet("continent")]
    public IActionResult GetContinentPopulation([FromQuery] string name)
    {
        decimal continentPopulation = _context.Countries
            .Where(c => c.Continent == name)
            .Sum(c => c.Population);
        return Ok(continentPopulation);
    }

    [HttpGet("region")]
    public IActionResult GetRegionPopulation([FromQuery] string name)
    {
        decimal regionPopulation = _context.Countries
            .Where(c => c.Region == name)
            .Sum(c => c.Population);
        return Ok(regionPopulation);
    }
    
    [HttpGet("country")]
    public IActionResult GetCountryPopulation([FromQuery] string name)
    {
        var countryPopulation = _context.Countries
            .Where(c => c.Name == name)
            .Sum(c => c.Population);
        return Ok(countryPopulation);
    }

    [HttpGet("district")]
    public IActionResult GetDistrictPopulation([FromQuery] string name)
    {
        var districtPopulation = _context.Cities
            .Where(c => c.District == name)
            .Sum(c => c.Population);
        return Ok(districtPopulation);
    }

    [HttpGet("city")]
    public IActionResult GetCityPopulation([FromQuery] string name)
    {
        var cityPopulation = _context.Cities
            .Where(c => c.Name == name)
            .Select(c => c.Population)
            .FirstOrDefault();
        return Ok(cityPopulation);
    }

    [HttpGet("by-continent")]
    public IActionResult GetPopulationByContinent()
    {
        var populationByContinent = _context.Countries
            .GroupBy(c => c.Continent)
            .Select(g => new PopulationSummary
            {
                Continent = g.Key,
                PopulationInCities = g.Sum(c => c.Cities.Sum(city => city.Population)),
                PopulationNotInCities = g.Sum(c => c.Population) - g.Sum(c => c.Cities.Sum(city => city.Population))
            })
            .ToList();
        return Ok(populationByContinent);
    }

    [HttpGet("by-region")]
    public IActionResult GetPopulationByRegion()
    {
        var populationByRegion = _context.Countries
            .GroupBy(c => c.Region )
            .Select(g => new PopulationSummary
            {
                Region = g.Key,
                PopulationInCities = g.Sum(c => c.Cities.Sum(city => city.Population)),
                PopulationNotInCities = g.Sum(c => c.Population) - g.Sum(c => c.Cities.Sum(city => city.Population))
            })
            .ToList();
        return Ok(populationByRegion);
    }

    [HttpGet("by-country")]
    public IActionResult GetPopulationByCountry()
    {
        var populationByCountry = _context.Countries
            .Select(c => new PopulationSummary
            {
                Country = c.Name,
                PopulationInCities = c.Cities.Sum(city => city.Population),
                PopulationNotInCities = c.Population - c.Cities.Sum(city => city.Population)
            })
            .ToList();
        return Ok(populationByCountry);
    }
}