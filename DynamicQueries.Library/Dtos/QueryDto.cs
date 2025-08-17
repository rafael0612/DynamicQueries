namespace DynamicQueries.Library.Dtos;

public class QueryDto(string DataSource, string[] FieldNames, FilterDto[] Filters, OrderDto[] Orders)
{
    public string DataSource => DataSource;
    public string[] FieldNames => FieldNames;
    public FilterDto[] Filters => Filters;
    public OrderDto[] Orders => Orders;
}
