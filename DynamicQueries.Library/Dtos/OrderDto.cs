namespace DynamicQueries.Library.Dtos;

public class OrderDto(string _FieldName, string _OrderType)
{
    public string FieldName => _FieldName;
    public string OrderType => _OrderType;
}
