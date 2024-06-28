using Microsoft.AspNetCore.Mvc;
using System.Linq;


public static class QueryableExtensions
{
    public static IQueryable<T> ApplyLimit<T>(this IQueryable<T> query, int? limit)
    {
        if (limit.HasValue)
        {
            return query.Take(limit.Value);
        }
        else
        {
            return query;
        }
    }
}


[Route("api/top-populated/")]
[ApiController]
public class PopulationController : ControllerBase
{
    private readonly AppDbContext _context;

    public PopulationController(AppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    [HttpGet("countries")]
    public IActionResult GetTopPopulatedCountries([FromQuery] int? limit)
    {
        var countries = _context.Countries
            .OrderByDescending(c => c.Population)
            .ApplyLimit(limit)
            .ToList();
        return Ok(countries);
    }

    [HttpGet("countries-in-continent")]
    public IActionResult GetTopPopulatedCountriesInContinent([FromQuery] string continent, [FromQuery] int? limit)
    {
        var countries = _context.Countries
            .Where(c => c.Continent == continent)
            .OrderByDescending(c => c.Population)
            .ApplyLimit(limit)
            .ToList();
        return Ok(countries);
    }

    [HttpGet("countries-in-region")]
    public IActionResult GetTopPopulatedCountriesInRegion([FromQuery] string region, [FromQuery] int? limit)
    {
        var countries = _context.Countries
            .Where(c => c.Region == region)
            .OrderByDescending(c => c.Population)
            .ApplyLimit(limit)
            .ToList();
        return Ok(countries);
    }

    [HttpGet("cities")]
    public IActionResult GetTopPopulatedCities([FromQuery] int? limit)
    {
        var cities = _context.Cities
            .OrderByDescending(c => c.Population)
            .ApplyLimit(limit)
            .ToList();
        return Ok(cities);
    }

    [HttpGet("cities-in-continent")]
    public IActionResult GetTopPopulatedCitiesInContinent([FromQuery] string continent, [FromQuery] int? limit)
    {
        var cities = _context.Cities
            .Where(c => c.Country.Continent == continent)
            .OrderByDescending(c => c.Population)
            .ApplyLimit(limit)
            .ToList();
        return Ok(cities);
    }

    [HttpGet("cities-in-region")]
    public IActionResult GetTopPopulatedCitiesInRegion([FromQuery] string region, [FromQuery] int? limit)
    {
        var cities = _context.Cities
            .Where(c => c.Country.Region == region)
            .OrderByDescending(c => c.Population)
            .ApplyLimit(limit)
            .ToList();
        return Ok(cities);
    }

    [HttpGet("cities-in-country")]
    public IActionResult GetTopPopulatedCitiesInCountry([FromQuery] string countryCode, [FromQuery] int? limit)
    {
        var cities = _context.Cities
            .Where(c => c.CountryCode == countryCode)
            .OrderByDescending(c => c.Population)
            .ApplyLimit(limit)
            .ToList();
        return Ok(cities);
    }

    [HttpGet("cities-in-district")]
    public IActionResult GetTopPopulatedCitiesInDistrict([FromQuery] string district, [FromQuery] int? limit)
    {
        var cities = _context.Cities
            .Where(c => c.District == district)
            .OrderByDescending(c => c.Population)
            .ApplyLimit(limit)
            .ToList();
        return Ok(cities);
    }

    [HttpGet("capital")]
    public IActionResult GetTopPopulatedCapitalCities([FromQuery] int? limit)
    {
        var capital = _context.Countries
            .Where(c => c.Capital.HasValue)
            .Select(c => new
            {
                c.Name,
                CapitalCity = _context.Cities.FirstOrDefault(city => city.ID == c.Capital),
                c.Population
            })
            .OrderByDescending(c => c.Population)
            .ToList();
        return Ok(capital);
    }

    [HttpGet("capital-in-continent")]
    public IActionResult GetTopPopulatedCapitalCitiesInContinent([FromQuery] string continent, [FromQuery] int? limit)
    {
        var capital = _context.Countries
            .Where(c => c.Continent == continent && c.Capital.HasValue)
            .Select(c => new
            {
                c.Name,
                CapitalCity = _context.Cities.FirstOrDefault(city => city.ID == c.Capital),
                c.Population
            })
            .OrderByDescending(c => c.Population)
            .ApplyLimit(limit)
            .ToList();
        return Ok(capital);
    }

    [HttpGet("capital-in-region")]
    public IActionResult GetTopPopulatedCapitalCitiesInRegion([FromQuery] string region, [FromQuery] int? limit)
    {
        var capital = _context.Countries
            .Where(c => c.Region == region && c.Capital.HasValue)
            .Select(c => _context.Cities.First(city => city.ID == c.Capital))
            .OrderByDescending(c => c.Population)
            .ApplyLimit(limit)
            .ToList();
        return Ok(capital);
    }
}
