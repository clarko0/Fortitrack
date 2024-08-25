namespace Common.Managers;
public interface IManager<TDto, TDb, TFilters>
{
    public List<TDto> List(TFilters filters);
    public TDto GetById(int id);
    public void Create(TDto dto);
    public void Update(TDto dto);
    public void ArchiveById(int id);
    public IQueryable<TDto> SelectAsDto(IQueryable<TDb> query);
    public IQueryable<TDb> ApplyFilters(IQueryable<TDb> query, TFilters filters);
}