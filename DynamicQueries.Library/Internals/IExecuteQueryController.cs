using DynamicQueries.Library.Dtos;
using DynamicQueries.Library.Result;
using System.Dynamic;
namespace DynamicQueries.Library.Internals;

internal interface IExecuteQueryController
{
    task<HandleRequestResult<IEnumerable<ExpandoObject>>> HandleRequestAsync(QueryDto queryDto);
}
