using System.Linq.Expressions;
using System.Reflection;

namespace vebtech_test.BLL.Utilites.Extensions
{
    public static class LinqExtensions
    {
        public static IEnumerable<T> OrderByProperty<T>(this IEnumerable<T> source, string propertyName, string sortOrder)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (string.IsNullOrEmpty(propertyName))
            {
                return source;
            }

            var type = typeof(T);
            var property = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

            if (property == null)
            {
                throw new ArgumentException($"Property '{propertyName}' not found on type '{type}'.");
            }

            if (!property.PropertyType.IsValueType && property.PropertyType != typeof(string))
            {
                throw new ArgumentException($"Cannot order by non-primitive or non-string property '{propertyName}'.");
            }

            var parameter = Expression.Parameter(type, "x");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);

            string methodName = sortOrder.Equals("desc", StringComparison.OrdinalIgnoreCase) ? "OrderByDescending" : "OrderBy";

            var resultExp = Expression.Call(
                typeof(Queryable),
                methodName,
                new[] { type, property.PropertyType },
                source.AsQueryable().Expression,
                Expression.Quote(orderByExp)
            );

            return source.AsQueryable().Provider.CreateQuery<T>(resultExp);
        }
    }
}
