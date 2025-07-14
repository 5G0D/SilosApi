namespace SilosApi.Dto;

/// <summary>
/// DTO для работы с силосом
/// </summary>
public class SilosDto
{
    /// <summary>
    /// Идентификатор силоса
    /// </summary>
    /// <example>1</example>
    public int Id { get; set; }

    /// <summary>
    /// Название силоса
    /// </summary>
    /// <example>Силос #1</example>
    public string Name { get; set; }
    
    /// <summary>
    /// Название силоса
    /// </summary>
    /// <example>Пшеница</example>
    public string Culture { get; set; }

    /// <summary>
    /// Содержание горчака
    /// </summary>
    /// <example>0.5</example>
    public double? Gorchak { get; set; }

    /// <summary>
    /// Содержание белка
    /// </summary>
    /// <example>12.5</example>
    public double? Protein { get; set; }

    /// <summary>
    /// Содержание клопа
    /// </summary>
    /// <example>0.2</example>
    public double? Bug { get; set; }

    /// <summary>
    /// Содержание сорных растений
    /// </summary>
    /// <example>1.0</example>
    public double? Sornaya { get; set; }

    /// <summary>
    /// Содержание зерновых
    /// </summary>
    /// <example>98.0</example>
    public double? Zernovaya { get; set; }

    /// <summary>
    /// Неизвестный параметр
    /// </summary>
    /// <example>0.0</example>
    public double? Idk { get; set; }

    /// <summary>
    /// Натура
    /// </summary>
    /// <example>750</example>
    public double? Nature { get; set; }

    /// <summary>
    /// Влажность
    /// </summary>
    /// <example>14.0</example>
    public double? Humidity { get; set; }

    /// <summary>
    /// Дата начала хранения
    /// </summary>
    /// <example>2023-09-01</example>
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// Год урожая
    /// </summary>
    /// <example>2023</example>
    public DateTime? HarvestYear { get; set; }

    /// <summary>
    /// Класс зерна
    /// </summary>
    /// <example>2</example>
    public int? Class { get; set; }

    /// <summary>
    /// Содержание клейковины
    /// </summary>
    /// <example>28.5</example>
    public double? Gluten { get; set; }

    /// <summary>
    /// Полнота зерна
    /// </summary>
    /// <example>99.0</example>
    public double? Fullness { get; set; }

    /// <summary>
    /// Общая вместимость
    /// </summary>
    /// <example>5000</example>
    public double? TotalFootage { get; set; }

    /// <summary>
    /// Свободная вместимость
    /// </summary>
    /// <example>1500</example>
    public double? FreeFootage { get; set; }

    /// <summary>
    /// Дополнительная информация
    /// </summary>
    /// <example>Хранится пшеница 2 класса</example>
    public string? AdditionalInfo { get; set; }
}