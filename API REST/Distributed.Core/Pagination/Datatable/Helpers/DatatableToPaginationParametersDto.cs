using Application.Core;
using Distributed.Core.Pagination.Datatable;
using Distributed.Core.Pagination.Datatable.Helpers;
using Infrastructure.CrossCutting.Enums;
using System.Linq;

namespace Distributed.Core.Datatable.Helpers
{
    public static class DatatableToPaginationParametersDto<TDto> where TDto : class
    {
        public static PaginationParametersDto<TDto> Convert(GridTable gridTable)
        {
            var columnOrder = gridTable.Order.First();
            var searchableColumns = gridTable.Columns.Where(p => p.Searchable).ToList();

            var filterParameterDto = new PaginationParametersDto<TDto>
            {
                Start = gridTable.Start,
                AmountRows = gridTable.Length,
                ColumnOrder = gridTable.Columns[columnOrder.Column].Name,
                OrderType = columnOrder.Dir == "asc" ? OrderType.Ascending : OrderType.Descending,
                WhereFilter = LambdaManager.ConvertToLambda<TDto>(searchableColumns, gridTable.Search),
                CurrentPage = (gridTable.Start / gridTable.Length)
            };

            return filterParameterDto;
        }
    }
}