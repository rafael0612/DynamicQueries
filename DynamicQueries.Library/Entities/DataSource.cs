namespace DynamicQueries.Library.Entities;

public class DataSource(string _Name, string _Description, Type _ElementType, IQueryable _Queryable,
                        DataSourcePropertyInfo[] _Properties)
{
    public string Name => _Name;
    public string Description => _Description;
    public Type ElementType => _ElementType;
    public IQueryable Queryable => _Queryable;
    public DataSourcePropertyInfo[] Properties => _Properties;

    public PropertyInfo GetPropertyInfo(string Name) =>
        ElementType.GetProperty(Name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

    public PropertyInfo[] GetAllPropertyInfos() =>
        [.. Properties.Select(p => GetPropertyInfo(p.Name))];
}