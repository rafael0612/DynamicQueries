namespace DynamicQueries.Library.Internals;

internal interface IExecuteQueryController
{
    Task<HandleRequestResult<IEnumerable<ExpandoObject>>> HandleRequestAsync(QueryDto queryDto);
}