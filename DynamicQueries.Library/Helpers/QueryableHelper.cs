namespace DynamicQueries.Library.Helpers;
internal static class QueryableHelper
{
    public static MethodInfo GetSelectMethodInfo(Type elementType, Type returnType) =>
            typeof(Queryable)
            .GetMethods()
            .First(m => m.Name == "Select" && m.GetParameters().Length == 2)
            .MakeGenericMethod(elementType, returnType);
}