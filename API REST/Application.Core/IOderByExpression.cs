using AutoMapper;
using System.Linq.Expressions;

namespace Application.Core
{
    public interface IOderByExpression
    {
        LambdaExpression GetLambdaExpression<TEntity>(IMapper mapper);
    }
}