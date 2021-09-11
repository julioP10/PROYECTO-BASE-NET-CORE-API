using System.Linq.Expressions;
using Distributed.Core.Pagination.Core;

namespace Distributed.Core.Pagination.OperationsComparison
{
    public class EqualsOperationComparison : IOperationComparison
    {
        public Expression GetOperationComparison<T>(ParameterExpression parameterExpression, string itemField, string searchValue)
          where T : class
        {
            var lambdaAccess = BaseOperationComparison.GetMemberAccessLambda<T>(parameterExpression, itemField);
            var expressionValue = BaseOperationComparison.GetSearchValueExpression<T>(searchValue, itemField);

            return expressionValue == default ? default(Expression) : Expression.Equal(lambdaAccess, expressionValue);
        }
    }
}