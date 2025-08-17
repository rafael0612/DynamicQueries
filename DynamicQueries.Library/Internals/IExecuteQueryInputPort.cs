using DynamicQueries.Library.Dtos;
using System.Dynamic;
namespace DynamicQueries.Library.Internals;

internal interface IExecuteQueryInputPort
{
    Task<IEnumerable<ExpandoObject>> HandleRequestAsync(QueryDto queryDto);
}
