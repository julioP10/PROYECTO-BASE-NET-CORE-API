using System.Linq.Expressions;

namespace Distributed.Core.Pagination.Core
{
    public interface IOperationComparison
    {
        Expression GetOperationComparison<T>(ParameterExpression parameterExpression, string itemField, string searchValue)
            where T : class;
    }
}