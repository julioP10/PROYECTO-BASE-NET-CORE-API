using System;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;

namespace Distributed.Core.Pagination.Core
{
    public class BaseOperationComparison
    {
        public static Expression GetMemberAccessLambda<T>(ParameterExpression arg, string itemField) where T : class
        {
            string[] propertyList = itemField.Split('.');
            Expression expression = arg;

            Type currentType = typeof(T);

            foreach (string property in propertyList)
            {
                PropertyInfo propertyInfo = currentType.GetProperty(property);

                expression = Expression.MakeMemberAccess(expression, propertyInfo);
                currentType = propertyInfo.PropertyType;
            }

            return expression;
        }


        public static Type GetPropertyType<T>(string itemField) where T : class
        {
            string[] propertyList = itemField.Split('.');
            Type currentType = typeof(T);

            foreach (string property in propertyList)
            {
                PropertyInfo propertyInfo = currentType.GetProperty(property);
                currentType = propertyInfo.PropertyType;
            }

            return currentType;
        }

        public static Expression GetSearchValueExpression<T>(string searchValue, string itemField) where T : class
        {
            var propertyType = GetPropertyType<T>(itemField);

            if (propertyType == typeof(DateTime) || propertyType == typeof(DateTime?))
            {
                var isDateParseable = DateTime.TryParseExact(searchValue, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime parsedDate);

                return isDateParseable ? Expression.Constant(parsedDate) : default;
            }

            var escapedExpression = !string.IsNullOrEmpty(searchValue)
                ? Expression.Constant(searchValue.ToLower().Trim())
                : default;

            return escapedExpression;
        }

        public static Expression GreaterThanOrEqualNullable(Expression e1, Expression e2)
        {
            if (IsNullableType(e1.Type) && !IsNullableType(e2.Type))
                e2 = Expression.Convert(e2, e1.Type);
            else if (!IsNullableType(e1.Type) && IsNullableType(e2.Type))
                e1 = Expression.Convert(e1, e2.Type);

            return Expression.GreaterThanOrEqual(e1, e2);
        }

        public static Expression LowerThanOrEqualNullable(Expression e1, Expression e2)
        {
            if (IsNullableType(e1.Type) && !IsNullableType(e2.Type))
                e2 = Expression.Convert(e2, e1.Type);
            else if (!IsNullableType(e1.Type) && IsNullableType(e2.Type))
                e1 = Expression.Convert(e1, e2.Type);

            return Expression.LessThanOrEqual(e1, e2);
        }

        public static bool IsNullableType(Type t)
        {
            return t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
    }
}