namespace DynamicQueries.Library.Dtos;

public class QueryDto(string _DataSource, string[] _FieldNames, FilterDto[] _Filters, OrderDto[] _Orders)
{
    public string DataSource => _DataSource;
    public string[] FieldNames => _FieldNames;
    public FilterDto[] Filters => _Filters;
    public OrderDto[] Orders => _Orders;
}
