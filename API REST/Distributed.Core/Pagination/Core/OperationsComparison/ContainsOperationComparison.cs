using System.Linq.Expressions;
using System.Reflection;
using Distributed.Core.Pagination.Core;

namespace Distributed.Core.Pagination.OperationsComparison
{
    public class ContainsOperationComparison : IOperationComparison
    {
        public Expression GetOperationComparison<T>(ParameterExpression parameterExpression, string itemField, string searchValue)
           where T : class
        {
            var lambdaAccess = BaseOperationComparison.GetMemberAccessLambda<T>(parameterExpression, itemField);
            var expressionValue = BaseOperationComparison.GetSearchValueExpression<T>(searchValue, itemField);

            MethodInfo miBeginWith = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            return expressionValue == default ? default(Expression) : Expression.Call(lambdaAccess, miBeginWith, expressionValue);
        }
    }
}