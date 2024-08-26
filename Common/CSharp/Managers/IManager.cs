namespace Common.Managers;
public interface IManager<TDto, TDb, TFilters>
{
    public List<TDto> List(TFilters filters);
    public TDto GetById(int id);
    public TDto Create(TDto dto);
    public TDto Update(TDto dto);
    public TDto ArchiveById(int id);
    public IQueryable<TDto> SelectAsDto(IQueryable<TDb> query);
    public IQueryable<TDb> ApplyFilters(IQueryable<TDb> query, TFilters filters);
}