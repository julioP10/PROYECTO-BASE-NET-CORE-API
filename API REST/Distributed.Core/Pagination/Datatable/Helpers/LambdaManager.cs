using Infraestructure.Crosscutting.TreeExpressions;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Distributed.Core.Pagination.Datatable.Helpers
{
    public static class LambdaManager
    {
        public static Expression<Func<T, bool>> ConvertToLambda<T>(List<ColumnModel> columnModels,
            SearchColumn searchColumn) where T : class
        {
            return ProcessFilterColumn<T>(searchColumn.Value, columnModels, searchColumn.Value != null ? 1 : 2);
        }

        private static Expression<Func<T, bool>> ProcessFilterColumn<T>(string searchValue, List<ColumnModel> columnModels, int logicalOperator) where T : class
        {
            Expression<Func<T, bool>> expresionsLambdaSet = null;

            ConstantExpression escapedExpression = !string.IsNullOrEmpty(searchValue) ?
                                                        Expression.Constant(searchValue.ToLower().Trim()) :
                                                        null;

            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "p");

            foreach (var columna in columnModels)
            {
                if (escapedExpression == null && string.IsNullOrEmpty(columna.Search.Value))
                    continue;

                var specificFilterColumnExpression = Expression.Constant(columna.Search.Value.ToLower().Trim());
                var comparisonContainsExpression = TreeExpressionHelper.GetContainsOperationComparison<T>(parameterExpression, columna.Name,
                    escapedExpression ?? specificFilterColumnExpression);

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

            return expresionsLambdaSet ?? PredicateBuilder.New<T>(true);
        }
    }
}