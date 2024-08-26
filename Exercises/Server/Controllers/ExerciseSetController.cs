using Common.Controllers;
using Microsoft.AspNetCore.Mvc;
using Server.Business;
using Server.Business.DataTransferObjects;
using Server.Business.FilterObjects;

namespace Server.Controllers;
public class ExerciseSetController : IApiController<IActionResult, ExerciseSetDto, ExerciseSetFilters>
{
    private ExerciseSetManager _exerciseSetManager { get; }

    public ExerciseSetController(ExerciseSetManager exerciseSetManager)
    {
        _exerciseSetManager = exerciseSetManager;
    }


    [HttpDelete]
    [Route("/sets/{id}")]
    public IActionResult ArchiveById(int id)
    {
        ExerciseSetDto result = _exerciseSetManager.ArchiveById(id);
        return new JsonResult(result);
    }

    [HttpGet]
    [Route("/sets/{id}")]
    public IActionResult GetById(int id)
    {
        ExerciseSetDto exerciseSet = _exerciseSetManager.GetById(id);
        return new JsonResult(exerciseSet);
    }

    [HttpGet]
    [Route("/sets")]
    public IActionResult List(ExerciseSetFilters filters)
    {
        List<ExerciseSetDto> exerciseSets = _exerciseSetManager.List(filters);
        return new JsonResult(exerciseSets);
    }

    [HttpPut]
    [Route("/sets")]
    public IActionResult Upsert(ExerciseSetDto video)
    {
        ExerciseSetDto result;

        bool exerciseSetIsMissingId = video.Id is null;
        if (exerciseSetIsMissingId)
        {
            result = _exerciseSetManager.Create(video);
        }
        else
        {
            result = _exerciseSetManager.Update(video);
        }

        return new JsonResult(result);
    }
}