using Common.Managers;
using DataModels;
using Server.Business.DataTransferObjects;
using Server.Business.FilterObjects;

namespace Server.Business;
public class ExerciseSetManager : IManager<ExerciseSetDto, ExerciseSet, ExerciseSetFilters>
{

    private ExerciseDataContext _dataContext { get; }

    public ExerciseSetManager(ExerciseDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public ExerciseSetDto GetById(int id)
    {
        ExerciseSetFilters filters = new(id);

        var query = _dataContext.ExerciseSets.AsQueryable();

        query = ApplyFilters(query, filters);

        var queryResult = SelectAsDto(query);

        ExerciseSetDto exerciseSet = queryResult.FirstOrDefault();

        bool exerciseSetNotFound = exerciseSet is null;
        if (exerciseSetNotFound)
        {
            throw new Exception($"Could not find exercise set with id: ({id})");
        }

        return exerciseSet;
    }

    public List<ExerciseSetDto> List(ExerciseSetFilters filters)
    {
        var query = _dataContext.ExerciseSets.AsQueryable();

        query = ApplyFilters(query, filters);

        List<ExerciseSetDto> queryResult = SelectAsDto(query).ToList();

        return queryResult;
    }

    public void ArchiveById(int id)
    {
        ExerciseSet exerciseSet = GetExerciseSetByIdAndValidate(id);

        exerciseSet.ArchivedOn = DateTime.UtcNow;

        _dataContext.SaveChanges();
    }

    public void Create(ExerciseSetDto dto)
    {
        ExerciseSet dbExerciseSet = new();

        ValidateExerciseSetCreation(dto);

        dbExerciseSet.ExerciseId = dto.ExerciseId;
        dbExerciseSet.Date = dto.Date.Value;
        dbExerciseSet.RepCount = dto.RepCount.Value;
        dbExerciseSet.Weight = dto.Weight.Value;

        dbExerciseSet.CreatedOn = DateTime.UtcNow;
        dbExerciseSet.LastUpdatedOn = DateTime.UtcNow;

        _dataContext.ExerciseSets.Add(dbExerciseSet);
        _dataContext.SaveChanges();
    }

    public void Update(ExerciseSetDto dto)
    {
        ExerciseSet dbExerciseSet = GetExerciseSetByIdAndValidate(dto.Id.Value);

        bool dateHasValue = dto.Date is not null;
        if (dateHasValue)
        {
            dbExerciseSet.Date = dto.Date.Value;
        }

        bool repCountHasValue = dto.RepCount is not null;
        if (repCountHasValue)
        {
            ValidateRepCount(dto.RepCount);
            dbExerciseSet.RepCount = dto.RepCount.Value;
        }

        bool weightHasValue = dto.Weight is not null;
        if (weightHasValue)
        {
            ValidateWeight(dto.Weight);
            dbExerciseSet.Weight = dto.Weight.Value;
        }

        dbExerciseSet.LastUpdatedOn = DateTime.UtcNow;

        _dataContext.SaveChanges();
    }

    public IQueryable<ExerciseSetDto> SelectAsDto(IQueryable<ExerciseSet> query)
    {
        return query.Select(e => new ExerciseSetDto(
            e.Id, // : id
            e.ExerciseId, // : exerciseId
            e.Date, // : date
            e.RepCount, // : repCount
            e.Weight, // : weight
            e.CreatedOn, // : createdOn
            e.LastUpdatedOn, // : lastUpdatedOn
            e.ArchivedOn // : archivedOn
        ));
    }

    public IQueryable<ExerciseSet> ApplyFilters(IQueryable<ExerciseSet> query, ExerciseSetFilters filters)
    {
        bool applyIdFilter = filters.Id is not null;
        if (applyIdFilter)
        {
            query = query.Where(e => e.Id == filters.Id);
        }

        return query;
    }

    #region Query Methods

    private ExerciseSet GetExerciseSetByIdAndValidate(int exerciseSetId)
    {
        ExerciseSetFilters filters = new(exerciseSetId);

        var query = _dataContext.ExerciseSets.AsQueryable();

        query = ApplyFilters(query, filters);

        ExerciseSet exerciseSet = query.FirstOrDefault();

        bool exerciseSetNotFound = exerciseSet is null;
        if (exerciseSetNotFound)
        {
            throw new Exception($"Could not find exercise set with id: ({exerciseSetId})");
        }

        return exerciseSet;
    }

    #endregion

    #region Data Validation

    private static void ValidateDate(DateTime? date)
    {
        bool dateIsNotSet = date is null;
        if (dateIsNotSet)
        {
            throw new Exception("Date must have a value");
        }
    }

    private static void ValidateRepCount(int? repCount)
    {
        bool repCountIsLessThanOne = repCount <= 0;
        if (repCountIsLessThanOne)
        {
            throw new Exception("Rep count must be greater than 0");
        }
    }

    private static void ValidateWeight(double? weight)
    {
        bool weightIsLessThanZero = weight < 0;
        if (weightIsLessThanZero)
        {
            throw new Exception("Weight must be greater than or equal to 0");
        }
    }

    private void ValidateExerciseId(int exerciseId)
    {
        bool exerciseNotFound = false == _dataContext.Exercises.Any(e => e.Id == exerciseId);
        if (exerciseNotFound)
        {
            throw new Exception($"Could not find exercise with id: ({exerciseId})");
        }
    }

    private void ValidateExerciseSetCreation(ExerciseSetDto dto)
    {
        bool dateIsNotSet = dto.Date is null;
        if (dateIsNotSet)
        {
            throw new Exception("Date must have a value");
        }

        bool repCountIsNotSet = dto.RepCount is null;
        if (repCountIsNotSet)
        {
            throw new Exception("Rep count must have a value");
        }

        bool weightIsNotSet = dto.Weight is null;
        if (weightIsNotSet)
        {
            throw new Exception("Weight must have a value");
        }

        ValidateDate(dto.Date);
        ValidateRepCount(dto.RepCount);
        ValidateWeight(dto.Weight);
        ValidateExerciseId(dto.ExerciseId);
    }

    #endregion
}