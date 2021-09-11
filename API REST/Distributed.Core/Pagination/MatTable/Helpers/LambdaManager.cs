using Infraestructure.Crosscutting;
using Infraestructure.Crosscutting.TreeExpressions;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Distributed.Core.Pagination.MatTable.Helpers
{
    public static class LambdaManager
    {
        public static Expression<Func<T, bool>> ConvertToLambda<T>(List<ColumnModel> columnModels,
          string searchValue) where T : class
        {
            return ProcessFilterColumn<T>(searchValue, columnModels, 1);
        }

        private static Expression<Func<T, bool>> ProcessFilterColumn<T>(string searchValue, List<ColumnModel> columnModels, int logicalOperator) where T : class
        {
            Expression<Func<T, bool>> expresionsLambdaSet = null;

            ConstantExpression escapedExpression = !string.IsNullOrEmpty(searchValue) ?
                                                        Expression.Constant(searchValue.ToLower().Trim()) :
                                                        null;

            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "p");

            if (escapedExpression != null)
            {
                foreach (var columna in columnModels)
                {
                    var pascalCaseField = StringHelper.ToPascalCase(columna.Field);
                    var comparisonContainsExpression = TreeExpressionHelper.GetContainsOperationComparison<T>(parameterExpression, pascalCaseField,
                        escapedExpression);

                    var expressionLambdaFilter = Expression.Lambda<Func<T, bool>>(comparisonContainsExpression, parameterExpression);

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