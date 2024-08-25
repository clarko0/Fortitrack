namespace Server.Business.DataTransferObjects;
public class ExerciseSetDto
{
    public int? Id { get; set; }

    public int ExerciseId { get; set; }

    public DateTime? Date { get; set; }
    public int? RepCount { get; set; }
    public double? Weight { get; set; }

    public DateTime CreatedOn { get; set; }
    public DateTime LastUpdatedOn { get; set; }
    public DateTime? ArchivedOn { get; set; }

    public ExerciseSetDto()
    {

    }

    public ExerciseSetDto
    (
        int id,
        int exerciseId,
        DateTime date,
        int repCount,
        double weight,
        DateTime createdOn,
        DateTime lastUpdatedOn,
        DateTime? archivedOn
    )
    {
        Id = id;
        ExerciseId = exerciseId;
        Date = date;
        RepCount = repCount;
        Weight = weight;
        CreatedOn = createdOn;
        LastUpdatedOn = lastUpdatedOn;
        ArchivedOn = archivedOn;
    }
}