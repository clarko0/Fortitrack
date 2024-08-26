using Common.Controllers;
using Microsoft.AspNetCore.Mvc;
using Server.Business;
using Server.Business.DataTransferObjects;
using Server.Business.FilterObjects;

namespace Server.Controllers;
public class ExerciseController : IApiController<IActionResult, ExerciseDto, ExerciseFilters>
{
    private ExerciseManager _exerciseManager { get; }

    public ExerciseController(ExerciseManager exerciseManager)
    {
        _exerciseManager = exerciseManager;
    }


    [HttpDelete]
    [Route("/exercises/{id}")]
    public IActionResult ArchiveById(int id)
    {
        ExerciseDto result = _exerciseManager.ArchiveById(id);
        return new JsonResult(result);
    }


    [HttpGet]
    [Route("/exercises/{id}")]
    public IActionResult GetById(int id)
    {
        var result = _exerciseManager.GetById(id);
        return new JsonResult(result);
    }

    [HttpGet]
    [Route("/exercises")]
    public IActionResult List(ExerciseFilters filters)
    {
        var result = _exerciseManager.List(filters);
        return new JsonResult(result);
    }

    [HttpPut]
    [Route("/exercises")]
    public IActionResult Upsert(ExerciseDto exercise)
    {
        ExerciseDto result;

        bool exerciseIsMissingId = exercise.Id is null;
        if (exerciseIsMissingId)
        {
            result = _exerciseManager.Create(exercise);
        }
        else
        {
            result = _exerciseManager.Update(exercise);
        }

        return new JsonResult(result);
    }
}