using System.Linq.Expressions;
using System.Reflection;
using Distributed.Core.Pagination.Core;

namespace Distributed.Core.Pagination.OperationsComparison
{
    public class EndsWithOperationComparison : IOperationComparison
    {
        public Expression GetOperationComparison<T>(ParameterExpression parameterExpression, string itemField, string searchValue)
           where T : class
        {
            var lambdaAccess = BaseOperationComparison.GetMemberAccessLambda<T>(parameterExpression, itemField);
            var expressionValue = BaseOperationComparison.GetSearchValueExpression<T>(searchValue, itemField);

            MethodInfo miBeginWith = typeof(string).GetMethod("EndsWith", new[] { typeof(string) });
            return expressionValue == default ? default(Expression) : Expression.Call(lambdaAccess, miBeginWith, expressionValue);
        }
    }
}