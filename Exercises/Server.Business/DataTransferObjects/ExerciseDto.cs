namespace Server.Business.DataTransferObjects;
public class ExerciseDto
{
    public int? Id { get; set; }
    public string Name { get; set; }

    public double MaximumWeight { get; set; }
    public List<ExerciseSetDto> ExerciseSets { get; set; }

    public DateTime CreatedOn { get; set; }
    public DateTime LastUpdatedOn { get; set; }
    public DateTime? ArchivedOn { get; set; }

    public ExerciseDto()
    {

    }

    public ExerciseDto(int id, string name, double maximumWeight, List<ExerciseSetDto> exerciseSets, DateTime createdOn, DateTime lastUpdatedOn, DateTime? archivedOn)
    {
        Id = id;
        Name = name;
        MaximumWeight = maximumWeight;
        ExerciseSets = exerciseSets;
        CreatedOn = createdOn;
        LastUpdatedOn = lastUpdatedOn;
        ArchivedOn = archivedOn;
    }
}