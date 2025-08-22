namespace DynamicQueries.Library.Extensions;
internal static class IEnumerableExtensions
{
    public static IEnumerable<ExpandoObject> ConvertToExpando(this IEnumerable<object[]> data, PropertyInfo[] properties)
    {
        foreach (object[] PropertyValues in data)
        {
            IDictionary<string, object> ExpandoDict = new ExpandoObject();
            for (int i = 0; i < properties.Length; i++)
            {
                ExpandoDict[properties[i].Name] = PropertyValues[i];
            }
            yield return (ExpandoObject)ExpandoDict;
        }
    }
}