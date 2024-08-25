using Common.Managers;
using DataModels;
using Server.Business.DataTransferObjects;
using Server.Business.FilterObjects;

namespace Server.Business;
public class ExerciseManager : IManager<ExerciseDto, Exercise, ExerciseFilters>
{
    private ExerciseDataContext _dataContext { get; }

    public ExerciseManager(ExerciseDataContext dataContext, ExerciseSetManager exerciseSetManager)
    {
        _dataContext = dataContext;
    }

    public List<ExerciseDto> List(ExerciseFilters filters)
    {
        var query = _dataContext.Exercises.AsQueryable();

        query = ApplyFilters(query, filters);

        List<ExerciseDto> queryResult = SelectAsDto(query).ToList();

        return queryResult;
    }

    public void ArchiveById(int id)
    {
        ExerciseFilters filters = new(id);

        var query = _dataContext.Exercises.AsQueryable();

        query = ApplyFilters(query, filters);

        Exercise exercise = query.FirstOrDefault();

        bool exerciseNotFound = exercise is null;
        if (exerciseNotFound)
        {
            throw new Exception($"Could not find exercise with id: ({id})");
        }

        exercise.ArchivedOn = DateTime.UtcNow;

        _dataContext.SaveChanges();
    }

    public void Create(ExerciseDto dto)
    {
        Exercise dbExercise = new();

        bool nameIsEmpty = string.IsNullOrWhiteSpace(dto.Name);
        if (nameIsEmpty)
        {
            throw new Exception("Exercise name cannot be empty");
        }

        dto.Name = dto.Name.Trim();

        bool nameIsTooLong = dto.Name.Length > Exercise.MAX_NAME_LENGTH;
        if (nameIsTooLong)
        {
            throw new Exception($"Exercise name cannot be longer than {Exercise.MAX_NAME_LENGTH} characters");
        }

        dbExercise.Name = dto.Name;

        dbExercise.CreatedOn = DateTime.UtcNow;
        dbExercise.LastUpdatedOn = DateTime.UtcNow;

        _dataContext.Exercises.Add(dbExercise);

        _dataContext.SaveChanges();
    }

    public ExerciseDto GetById(int id)
    {
        ExerciseFilters filters = new(id);

        var query = _dataContext.Exercises.AsQueryable();

        query = ApplyFilters(query, filters);

        var queryResult = SelectAsDto(query);

        ExerciseDto exercise = queryResult.FirstOrDefault();

        bool exerciseNotFound = exercise is null;
        if (exerciseNotFound)
        {
            throw new Exception($"Could not find exercise with id : ({id})");
        }

        return exercise;
    }

    public IQueryable<ExerciseDto> SelectAsDto(IQueryable<Exercise> query)
    {
        return query.Select(e => new ExerciseDto(
            e.Id, // : id
            e.Name, // : name
            e.ExerciseSets
                .Select(es => new ExerciseSetDto(
                    es.Id, // : id
                    es.ExerciseId, // : exerciseId
                    es.Date, // : date
                    es.RepCount, // : repCount
                    es.Weight, // : weight
                    es.CreatedOn, // : createdOn
                    es.LastUpdatedOn, // : lastUpdatedOn
                    es.ArchivedOn // : archivedOn
                ))
                .ToList(), // : exerciseSets
            e.CreatedOn, // : createdOn
            e.LastUpdatedOn, // : lastUpdatedOn
            e.ArchivedOn // : archivedOn
        ));
    }

    public void Update(ExerciseDto dto)
    {
        ExerciseFilters filters = new(dto.Id);

        var query = _dataContext.Exercises.AsQueryable();

        query = ApplyFilters(query, filters);

        Exercise dbExercise = query.FirstOrDefault();

        bool exerciseNotFound = dbExercise is null;
        if (exerciseNotFound)
        {
            throw new Exception($"Could not find exercise with id : ({dto.Id})");
        }

        bool nameHasValue = dto.Name is not null;
        if (nameHasValue)
        {
            dto.Name = dto.Name.Trim();

            bool nameIsTooLong = dto.Name.Length > Exercise.MAX_NAME_LENGTH;
            if (nameIsTooLong)
            {
                throw new Exception($"Exercise name cannot be longer than {Exercise.MAX_NAME_LENGTH} characters");
            }

            dbExercise.Name = dto.Name;
        }

        dbExercise.LastUpdatedOn = DateTime.UtcNow;

        _dataContext.SaveChanges();
    }

    public IQueryable<Exercise> ApplyFilters(IQueryable<Exercise> query, ExerciseFilters filters)
    {
        bool applyIdFilter = filters.Id.HasValue;
        if (applyIdFilter)
        {
            query = query.Where(e => e.Id == filters.Id.Value);
        }

        bool applyNameFilter = false == string.IsNullOrWhiteSpace(filters.Name);
        if (applyNameFilter)
        {
            query = query
                .Where(e => e.Name.Contains(filters.Name));
        }

        return query;
    }
}