using Infrastructure.CrossCutting.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Core.Pagination
{
    public interface IPaginationParameters<T> where T : class
    {
        LambdaExpression ColumnOrder { get; set; }
        OrderType OrderType { get; set; }
        int Start { get; set; }
        int AmountRows { get; set; }
        Expression<Func<T, bool>> WhereFilter { get; set; }
    }
}
