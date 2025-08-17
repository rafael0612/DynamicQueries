using DynamicQueries.Library.Entities;
namespace DynamicQueries.Library.Interfaces;

public interface IRepository
{
    DataSource[] GetDataSourceByName(string Name);
    IEnumerable<DataSource> GetAllDataSources();
    Task<IEnumerable<object[]>> GetDataAsync(IQueryable<object[]> Queryable);
}
