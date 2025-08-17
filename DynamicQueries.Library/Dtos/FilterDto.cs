namespace DynamicQueries.Library.Dtos;

public class FilterDto(string FieldName, string Operation, string Value, string JoinWithNext)
{
    public string FieldName => FieldName;
    public string Operation => Operation;
    public string Value => Value;
    public string JoinWithNext => JoinWithNext;
}
