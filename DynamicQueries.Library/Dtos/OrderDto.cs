namespace DynamicQueries.Library.Dtos;

public class OrderDto(string FieldName, string OrderType)
{
    public string FieldName => FieldName;
    public string OrderType => OrderType;
}
