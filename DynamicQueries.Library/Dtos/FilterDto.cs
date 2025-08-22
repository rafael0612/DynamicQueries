namespace DynamicQueries.Library.Dtos;

public class FilterDto(string _FieldName, string _Operation, string _Value, string _JoinWithNext)
{
    public string FieldName => _FieldName;
    public string Operation => _Operation;
    public string Value => _Value;
    public string JoinWithNext => _JoinWithNext;
}
