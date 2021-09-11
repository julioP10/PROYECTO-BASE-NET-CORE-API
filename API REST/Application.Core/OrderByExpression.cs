using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using System;
using System.Linq.Expressions;

namespace Application.Core
{
    public class OrderByExpression<TDto, TProperty> : IOderByExpression
    {
        private readonly Expression<Func<TDto, TProperty>> _sort;

        public OrderByExpression(Expression<Func<TDto, TProperty>> sort)
        {
            _sort = sort;
        }

        public LambdaExpression GetLambdaExpression<TEntity>(IMapper mapper)
        {
            return mapper.MapExpression<Expression<Func<TEntity, TProperty>>>(_sort);
        }
    }
}