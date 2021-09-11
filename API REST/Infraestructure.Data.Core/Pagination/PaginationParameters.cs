using Domain.Core.Pagination;
using Infrastructure.CrossCutting.Enums;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Infraestructure.Data.Core.Pagination
{
    public class PaginationParameters<T>: IPaginationParameters<T> where T : class
    {
        public LambdaExpression ColumnOrder { get; set; }
        public OrderType OrderType { get; set; }
        public int Start { get; set; }
        public int AmountRows { get; set; }
        public Expression<Func<T, bool>> WhereFilter { get; set; }
        public Func<IQueryable<T>, IIncludableQueryable<T, object>> Includes { get; set; }
    }
}