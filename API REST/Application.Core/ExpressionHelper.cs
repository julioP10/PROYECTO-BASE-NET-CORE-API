using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Infraestructure.Crosscutting.TreeExpressions;
using Infraestructure.Data.Core.Pagination;
using LinqKit;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Application.Core
{
    public static class ExpressionHelper
    {
        public static PaginationParameters<TEntity> ConvertToPaginationParameterDomain<TEntity, TDto>(
            this PaginationParametersDto<TDto> parameters, IMapper mapper)
            where TEntity : class
            where TDto : class
        {
            var expressionEntity = mapper.MapExpression<Expression<Func<TEntity, bool>>>(parameters.WhereFilter);

            PropertyInfo propertyDtoOrderBy = typeof(TDto).GetProperty(parameters.ColumnOrder);
            var typeArguments = new[] { typeof(TDto), propertyDtoOrderBy.PropertyType };

            Type type = typeof(OrderByExpression<,>).MakeGenericType(typeArguments);

            var orderByLambda = (IOderByExpression)Activator.CreateInstance(type,
                TreeExpressionHelper.GetMemberAccessLambda<TDto>(parameters.ColumnOrder));

            var nuevoFiltroParameters = new PaginationParameters<TEntity>
            {
                ColumnOrder = orderByLambda.GetLambdaExpression<TEntity>(mapper),
                AmountRows = parameters.AmountRows,
                Start = parameters.Start,
                OrderType = parameters.OrderType,
                WhereFilter = expressionEntity
            };

            return nuevoFiltroParameters;
        }

        public static Expression<Func<TEntity, bool>> AddCondition<TEntity>(
            this Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, bool>> newRestriction)
        {
            if (predicate == null)
                return PredicateBuilder.New<TEntity>().And(newRestriction);

            return predicate.And(newRestriction);
        }
    }
}