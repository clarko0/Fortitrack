using Common.DataManagement;

namespace Server.Business.FilterObjects;
public class ExerciseSetFilters
{
    public int? Id { get; set; }
    public InclusionEnum Deleted { get; set; }

    public ExerciseSetFilters() : this(null, InclusionEnum.Both)
    {

    }

    public ExerciseSetFilters(int? id = null, InclusionEnum deleted = InclusionEnum.Both)
    {
        Id = id;
        Deleted = deleted;
    }
}