namespace DynamicQueries.Library.Internals;

internal interface IExecuteQueryInputPort
{
    Task<IEnumerable<ExpandoObject>> HandleQueryAsync(QueryDto queryDto);
}