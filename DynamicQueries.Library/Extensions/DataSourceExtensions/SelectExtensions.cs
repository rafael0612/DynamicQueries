namespace DynamicQueries.Library.Extensions.DataSourceExtensions;
internal static class SelectExtensions
{
    /*
     * source.Select(p => new object[] { p.Property1, p.Property2, ... })
    */
    public static SelectFieldsResult AddSelectedFields(this DataSource dataSource, string[] fieldNames)
    {
        // p
        ParameterExpression Parameter = Expression.Parameter(dataSource.ElementType, "p");
        PropertyInfo[] SelectedProperties;

        if (fieldNames.Length == 0)
        {
            SelectedProperties = [.. fieldNames
                .Select(name => dataSource.GetPropertyInfo(name))
                .Where(p => p != null)
                .ToArray()];
        }
        else
        {
            SelectedProperties = dataSource.GetAllPropertyInfos();
        }
        // p.Property1, p.Property2, ...
        IEnumerable<UnaryExpression> Bindings = SelectedProperties.Select(prop =>
        {
            //p.Property[i]
            MemberExpression PropertyAccess = Expression.Property(Parameter, prop);
            UnaryExpression BindingExpression;
            if (prop.PropertyType == typeof(double))
            {
                BindingExpression = Expression.Convert(PropertyAccess, typeof(decimal));
                BindingExpression = Expression.Convert(BindingExpression, typeof(object));
            }
            else
            {
                BindingExpression = Expression.Convert(PropertyAccess, typeof(object));
            }
            return BindingExpression;
        });
        // new object[] { p.Property1, p.Property2, ... }
        NewArrayExpression NewArray = Expression.NewArrayInit(typeof(object), Bindings);
        // Func<ElementType, object[]>
        Type LambdaType = typeof(Func<,>).MakeGenericType(dataSource.ElementType, typeof(object[]));
        // p => new object[] { p.Property1, p.Property2, ... }
        LambdaExpression Lambda = Expression.Lambda(LambdaType, NewArray, Parameter);
        // .Select<T, U>
        MethodInfo SelectMethod = QueryableHelper
            .GetSelectMethodInfo(dataSource.ElementType, typeof(object[]));
        //Queryable.Select<T, U>(p => new object[] { p.Property1, p.Property2, ... })
        IQueryable<object[]> QueryableResult = (IQueryable<object[]>)SelectMethod.Invoke(null, [dataSource.Queryable, Lambda]);
        return new SelectFieldsResult
        {
            Queryable = QueryableResult,
            Properties = SelectedProperties
        };
    }
}