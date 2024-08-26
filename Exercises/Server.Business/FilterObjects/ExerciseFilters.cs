using Common.DataManagement;

namespace Server.Business.FilterObjects;
public class ExerciseFilters
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public InclusionEnum Deleted { get; set; }

    public ExerciseFilters(int? id = null, string name = null, InclusionEnum deleted = InclusionEnum.Exclude)
    {
        Id = id;
        Name = name;
        Deleted = deleted;
    }

    public ExerciseFilters() : this(null, null, InclusionEnum.Exclude)
    {

    }
}