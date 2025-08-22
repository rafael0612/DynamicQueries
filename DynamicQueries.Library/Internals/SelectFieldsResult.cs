namespace DynamicQueries.Library.Internals;

internal class SelectFieldsResult
{
    public PropertyInfo[] Properties { get; set; }
    public IQueryable<object[]> Queryable { get; set; }    
}