namespace Common.Controllers
{
    public interface IApiController<TResult, TDto, TFilters>
    {
        public TResult List(TFilters filters);
        public TResult Upsert(TDto video);
        public TResult GetById(int id);
        public TResult ArchiveById(int id);
    }
}