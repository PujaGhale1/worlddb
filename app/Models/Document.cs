// Model for City
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class City
{
    [Key]
    public int ID { get; set; }
    public required string Name { get; set; }
    public required string CountryCode { get; set; }
    public required string District { get; set; }
    public long Population { get; set; }
    public required Country Country { get; set; }
}


// Model for Country
public class Country
{
    [Key]
    public required string Code { get; set; }
    public required string Name { get; set; }
    public required string Continent { get; set; }
    public required string Region { get; set; }
    public decimal SurfaceArea { get; set; }
    public short? IndepYear { get; set; }
    public long Population { get; set; }
    public decimal? LifeExpectancy { get; set; }
    public decimal? GNP { get; set; }
    public decimal? GNPOld { get; set; }
    public required string LocalName { get; set; }
    public required string GovernmentForm { get; set; }
    public string? HeadOfState { get; set; }
    public int? Capital { get; set; }
    public required string Code2 { get; set; }

    public required ICollection<City> Cities { get; set; }
    public required ICollection<CountryLanguage> Languages { get; set; }
}

// Model for CountryLanguage
public class CountryLanguage
{
    [Key]
    public required string CountryCode { get; set; }
    public required string Language { get; set; }
    public required string IsOfficial { get; set; }
    public decimal Percentage { get; set; }

    public required Country Country { get; set; }
}
