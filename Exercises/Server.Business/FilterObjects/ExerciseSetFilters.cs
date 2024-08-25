namespace Server.Business.FilterObjects;
public class ExerciseSetFilters
{
    public int? Id { get; set; }

    public ExerciseSetFilters() : this(null)
    {

    }

    public ExerciseSetFilters(int? id = null)
    {
        Id = id;
    }
}