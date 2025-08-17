namespace DynamicQueries.Library.ValueObjects;

public class DataSourcePropertyInfo(string Name, string Description, Type Type)
{
    public string Name => Name;
    public string Description => Description;
    public Type Type => Type;
}
