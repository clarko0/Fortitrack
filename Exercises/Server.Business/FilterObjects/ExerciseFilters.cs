namespace Server.Business.FilterObjects;
public class ExerciseFilters
{
    public int? Id { get; set; }
    public string Name { get; set; }

    public ExerciseFilters(int? id = null, string name = null)
    {
        Id = id;
        Name = name;
    }

    public ExerciseFilters() : this(null, null)
    {

    }
}