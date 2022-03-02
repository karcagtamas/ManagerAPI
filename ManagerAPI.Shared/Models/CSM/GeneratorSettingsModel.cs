using KarcagS.Shared.Attributes;
using ManagerAPI.Shared.DTOs.CSM;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Shared.Models.CSM;

/// <summary>
/// Generator Settings Model
/// </summary>
public class GeneratorSettingsModel
{
    /// <summary>
    /// Id
    /// </summary>
    [Required]
    [MaxLength(120)]
    public string Title { get; set; }

    /// <summary>
    /// Start
    /// </summary>
    [Required]
    public DateTime Start { get; set; }

    /// <summary>
    /// Finish
    /// </summary>
    [Required]
    public DateTime Finish { get; set; }

    /// <summary>
    /// Start Time
    /// </summary>
    public TimeSpan StartTime { get; set; }

    /// <summary>
    /// End Time
    /// </summary>
    public TimeSpan FinishTime { get; set; }

    /// <summary>
    /// Max Work hr
    /// </summary>
    [Required]
    [MinNumber(1)]
    [MaxNumber(8)]
    public int MaxWorkHour { get; set; } = 3;

    /// <summary>
    /// Min rest hour
    /// </summary>
    [Required]
    [MinNumber(1)]
    [MaxNumber(4)]
    public int MinRestHour { get; set; } = 1;

    /// <summary>
    /// Has any generated csomor
    /// </summary>
    public bool HasGeneratedCsomor { get; set; }

    /// <summary>
    /// Last generation 
    /// </summary>
    public DateTime? LastGeneration { get; set; }

    /// <summary>
    /// Persons
    /// </summary>
    public List<PersonModel> Persons { get; set; }

    /// <summary>
    /// Works
    /// </summary>
    public List<WorkModel> Works { get; set; }

    /// <summary>
    /// Init Generator Settings Model
    /// </summary>
    public GeneratorSettingsModel()
    {
        this.Title = "New Generator";
        var date = DateTime.UtcNow;
        date = date.AddMinutes(-date.Minute).AddSeconds(-date.Second);
        this.Start = date;
        this.Finish = date.AddDays(1);
        this.StartTime = this.Start.TimeOfDay;
        this.FinishTime = this.Finish.TimeOfDay;
        this.MaxWorkHour = 3;
        this.MinRestHour = 1;
        this.HasGeneratedCsomor = false;
        this.LastGeneration = null;

        this.Persons = new List<PersonModel>();
        this.Works = new List<WorkModel>();
    }

    /// <summary>
    /// Init Generator Settings Model from Settings
    /// </summary>
    /// <param name="settings"></param>
    public GeneratorSettingsModel(GeneratorSettings settings)
    {
        this.Title = settings.Title;
        this.Start = settings.Start;
        this.Finish = settings.Finish;
        this.StartTime = this.Start.TimeOfDay;
        this.FinishTime = this.Finish.TimeOfDay;
        this.MaxWorkHour = settings.MaxWorkHour;
        this.MinRestHour = settings.MinRestHour;
        this.HasGeneratedCsomor = settings.HasGeneratedCsomor;
        this.LastGeneration = settings.LastGeneration;

        this.Persons = settings.Persons.Select(x => new PersonModel(x)).OrderBy(x => x.Name).ToList();
        this.Works = settings.Works.Select(x => new WorkModel(x)).OrderBy(x => x.Name).ToList();
    }
}
