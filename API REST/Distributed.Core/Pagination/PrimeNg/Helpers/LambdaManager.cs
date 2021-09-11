using Infraestructure.Crosscutting;
using Infraestructure.Crosscutting.TreeExpressions;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Distributed.Core.Pagination.Core;
using Distributed.Core.Pagination.OperationsComparison;

namespace Distributed.Core.Pagination.PrimeNg.Helpers
{
    public static class LambdaManager
    {
        private static readonly Dictionary<string, IOperationComparison> OperationComparisons;

        static LambdaManager()
        {
            OperationComparisons = new Dictionary<string, IOperationComparison>
            {
                {"startswith", new BeginWithOperationComparison()},
                {"greaterthan", new GreatherThanOperationComparison()},
                {"lessthan", new LowerThanOperationComparison()},
                {"equal", new EqualsOperationComparison()},
                {"notequal", new NotEqualsOperationComparison()},
                {"endswith", new EndsWithOperationComparison()},
                {"contains", new ContainsOperationComparison()}
            };
        }

        public static Expression<Func<T, bool>> ConvertToLambda<T>(IReadOnlyCollection<ColumnModel> columnModels,
          string searchValue) where T : class
        {
            return ProcessFilterColumn<T>(searchValue, columnModels, 1);
        }

        private static Expression<Func<T, bool>> ProcessFilterColumn<T>(string searchValue, IReadOnlyCollection<ColumnModel> columnModels, int logicalOperator) where T : class
        {
            Expression<Func<T, bool>> expresionsLambdaSet = null;

            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "p");

            if (searchValue != null)
            {
                foreach (var column in columnModels)
                {
                    var pascalCaseField = StringHelper.ToPascalCase(column.Field);

                    var comparisonExpression = OperationComparisons[column.Operation ?? "contains"]
                        .GetOperationComparison<T>(parameterExpression, pascalCaseField, searchValue);

                    if(comparisonExpression == default) continue;
                    
                    var expressionLambdaFilter = Expression.Lambda<Func<T, bool>>(comparisonExpression, parameterExpression);

                    if (expresionsLambdaSet == null)
                        expresionsLambdaSet = expressionLambdaFilter;
                    else
                    {
                        expresionsLambdaSet = logicalOperator == 1 ?
                                                expresionsLambdaSet.Or(expressionLambdaFilter) :
                                                expresionsLambdaSet.And(expressionLambdaFilter);
                    }
                }
            }

            return expresionsLambdaSet ?? PredicateBuilder.New<T>(true);
        }
    }
}