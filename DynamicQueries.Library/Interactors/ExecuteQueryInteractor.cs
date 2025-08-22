namespace DynamicQueries.Library.Interactors;
internal class ExecuteQueryInteractor(IRepository repository) : IExecuteQueryInputPort
{
    public async Task<IEnumerable<ExpandoObject>> HandleQueryAsync(QueryDto queryDto)
    {
        IEnumerable<ExpandoObject> Result = [];
        DataSource DataSource = repository.GetDataSourceByName(queryDto.DataSource);
        
        if (DataSource != null)
        {
            SelectFieldsResult SelectResult = DataSource
                .AddFilters(queryDto.Filters)
                .AddOrderBy(queryDto.Orders)
                .AddSelectedFields(queryDto.FieldNames);

            var Data = await repository.GetDataAsync(SelectResult.Queryable);

            Result = Data.ConvertToExpando(SelectResult.Properties);
        }
        return Result;
    }
}