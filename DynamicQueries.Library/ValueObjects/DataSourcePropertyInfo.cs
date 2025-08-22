namespace DynamicQueries.Library.ValueObjects;

public class DataSourcePropertyInfo(string _Name, string _Description, Type _Type)
{
    public string Name => _Name;
    public string Description => _Description;
    public Type Type => _Type;
}
