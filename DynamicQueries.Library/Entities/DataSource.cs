using DynamicQueries.Library.ValueObjects;
using System.Reflection;
namespace DynamicQueries.Library.Entities;

public class DataSource(string Name, string Description, Type ElementType, IQueryable Queryable,
                        DataSourcePropertyInfo[] Properties)
{
    public string Name => Name;
    public string Description => Description;
    public Type ElementType => ElementType;
    public IQueryable Queryable => Queryable;
    public DataSourcePropertyInfo[] Properties => Properties;

    public PropertyInfo GetPropertyInfo(string Name) =>
        ElementType.GetProperty(Name, BlindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
    
    public PropertyInfo[] GetAllPropertyInfos() =>
        [.. Properties.Select(p => GetPropertyInfo(p.Name))];
}
