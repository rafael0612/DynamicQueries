namespace DynamicQueries.Library.Controllers;
internal class ExecuteQueryController(IExecuteQueryInputPort inputPort) : IExecuteQueryController
{
    public async Task<HandleRequestResult<IEnumerable<ExpandoObject>>> HandleRequestAsync(QueryDto queryDto)
    {
        HandleRequestResult<IEnumerable<ExpandoObject>> Result;
        try
        {
            var Data = await inputPort.HandleQueryAsync(queryDto);
            Result = new(Data);
        }
        catch (Exception ex)
        {
            Result = new(ex.Message);
        }
        return Result;
    }
}