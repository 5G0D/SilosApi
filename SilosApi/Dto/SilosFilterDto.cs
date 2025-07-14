namespace SilosApi.Dto;

public class SilosFilterDto
{
    public string? Name { get; set; }
    public string? Culture { get; set; }
    public double? GorchakFrom { get; set; }
    public double? GorchakTo { get; set; }
    public double? ProteinFrom { get; set; }
    public double? ProteinTo { get; set; }
    public double? BugFrom { get; set; }
    public double? BugTo { get; set; }
    public double? SornayaFrom { get; set; }
    public double? SornayaTo { get; set; }
    public double? ZernovayaFrom { get; set; }
    public double? ZernovayaTo { get; set; }
    public double? IdkFrom { get; set; }
    public double? IdkTo { get; set; }
    public double? NatureFrom { get; set; }
    public double? NatureTo { get; set; }
    public double? HumidityFrom { get; set; }
    public double? HumidityTo { get; set; }
    public DateTime? StartDateFrom { get; set; }
    public DateTime? StartDateTo { get; set; }
    public DateTime? HarvestYearFrom { get; set; }
    public DateTime? HarvestYearTo { get; set; }
    public int? ClassFrom { get; set; }
    public int? ClassTo { get; set; }
    public double? GlutenFrom { get; set; }
    public double? GlutenTo { get; set; }
    public double? FullnessFrom { get; set; }
    public double? FullnessTo { get; set; }
    public double? TotalFootageFrom { get; set; }
    public double? TotalFootageTo { get; set; }
    public double? FreeFootageFrom { get; set; }
    public double? FreeFootageTo { get; set; }
}