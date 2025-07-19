using Common.Orm.Filter;
using System.Linq.Expressions;
using System.Reflection;

namespace Common.Orm.Extensions
{
    public static class DynamicOrderBy
    {
        private static readonly MethodInfo OrderByMethod = typeof(Queryable).GetMethods().Single(method =>
           method.Name == "OrderBy" && method.GetParameters().Length == 2);

        private static readonly MethodInfo OrderByDescendingMethod = typeof(Queryable).GetMethods().Single(method =>
           method.Name == "OrderByDescending" && method.GetParameters().Length == 2);

        public static IQueryable<T> OrderByDynamic<T>(this IQueryable<T> source, IRepositoryFilter filters)
        {
            return source.OrderByDynamic(filters.OrderFields, filters.OrderByType);
        }

        public static IQueryable<T> OrderByDynamic<T>(this IQueryable<T> source, string[] orderFields, string orderByType = "DESC")
        {
            if (orderFields is null || orderFields.Length == 0)
                return source;

            if (orderByType == "DESC")
                return OrderByPropertyDescending(source, orderFields);

            return OrderByPropertyAscending(source, orderFields);
        }

        private static string DefinePropertyName(string[] propertyName)
        {
            var _propertyName = propertyName.LastOrDefault();
            var _parentProperty = _propertyName.Split('.')[0];
            return _parentProperty;
        }

        private static IQueryable<T> OrderByPropertyAscending<T>(this IQueryable<T> source, string[] orderFields)
        {
            var propertyName = DefinePropertyName(orderFields);

            if (typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) == null)
                return source;

            var paramterExpression = Expression.Parameter(typeof(T));
            var orderByProperty = Expression.Property(paramterExpression, propertyName);
            var lambda = Expression.Lambda(orderByProperty, paramterExpression);
            var genericMethod = OrderByMethod.MakeGenericMethod(typeof(T), orderByProperty.Type);
            var ret = genericMethod.Invoke(null, new object[] { source, lambda });
            return (IQueryable<T>)ret;
        }

        private static IQueryable<T> OrderByPropertyDescending<T>(this IQueryable<T> source, string[] orderFields)
        {
            var propertyName = DefinePropertyName(orderFields);

            if (typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) == null)
                return source;

            var paramterExpression = Expression.Parameter(typeof(T));
            var orderByProperty = Expression.Property(paramterExpression, propertyName);
            var lambda = Expression.Lambda(orderByProperty, paramterExpression);
            var genericMethod = OrderByDescendingMethod.MakeGenericMethod(typeof(T), orderByProperty.Type);
            var ret = genericMethod.Invoke(null, new object[] { source, lambda });
            return (IQueryable<T>)ret;
        }

    }
}
