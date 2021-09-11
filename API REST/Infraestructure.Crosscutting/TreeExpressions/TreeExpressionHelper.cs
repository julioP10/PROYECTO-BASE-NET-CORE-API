using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Infraestructure.Crosscutting.TreeExpressions
{
    public static class TreeExpressionHelper
    {
        public static Expression GetMemberAccessLambda<T>(ParameterExpression arg, string itemField) where T : class
        {
            string[] listaPropiedades = itemField.Split('.');
            Expression expression = arg;

            Type tipoActual = typeof(T);

            foreach (string propiedad in listaPropiedades)
            {
                PropertyInfo propertyInfo = tipoActual.GetProperty(propiedad);
                expression = Expression.MakeMemberAccess(expression, propertyInfo);
                tipoActual = propertyInfo.PropertyType;
            }

            return expression;
        }

        public static LambdaExpression GetMemberAccessLambda<T>(string itemField) where T : class
        {
            ParameterExpression p = Expression.Parameter(typeof(T), "p");
            return
                Expression.Lambda(
                    Expression.Property(p, typeof(T).GetProperty(itemField)), p);
        }

        public static Expression GetContainsOperationComparison<T>(string itemField, Expression expressionValue)
           where T : class
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "p");

            MethodInfo miBeginWith = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            return Expression.Call(GetMemberAccessLambda<T>(parameterExpression, itemField), miBeginWith, expressionValue);
        }

        public static Expression GetContainsOperationComparison<T>(ParameterExpression parameterExpression, string itemField, Expression expressionValue)
           where T : class
        {
            MethodInfo miBeginWith = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            return Expression.Call(GetMemberAccessLambda<T>(parameterExpression, itemField), miBeginWith, expressionValue);
        }
    }
}