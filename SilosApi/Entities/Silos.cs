namespace SilosApi.Entities;

public class Silos
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Culture { get; set; }
    public double? Gorchak { get; set; }
    public double? Protein { get; set; }
    public double? Bug { get; set; }
    public double? Sornaya { get; set; }
    public double? Zernovaya { get; set; }
    public double? Idk { get; set; }
    public double? Nature { get; set; }
    public double? Humidity { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? HarvestYear { get; set; }
    public int? Class { get; set; }
    public double? Gluten { get; set; }
    public double? Fullness { get; set; }
    public double? TotalFootage { get; set; }
    public double? FreeFootage { get; set; }
    public string? AdditionalInfo { get; set; }
}