using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModels;
public class Exercise
{
    public const int MAX_NAME_LENGTH = 255;

    public int Id { get; set; }

    [Column(TypeName = "VARCHAR")]
    [StringLength(MAX_NAME_LENGTH)]
    public string Name { get; set; }

    public List<ExerciseSet> ExerciseSets { get; set; }

    public DateTime CreatedOn { get; set; }
    public DateTime LastUpdatedOn { get; set; }
    public DateTime? ArchivedOn { get; set; }
}