namespace DataModels;
public class ExerciseSet
{
    public int Id { get; set; }

    public int ExerciseId { get; set; }
    public Exercise Exercise { get; set; }


    public DateTime Date { get; set; }
    public int RepCount { get; set; }
    public double Weight { get; set; }


    public DateTime CreatedOn { get; set; }
    public DateTime LastUpdatedOn { get; set; }
    public DateTime? ArchivedOn { get; set; }
}