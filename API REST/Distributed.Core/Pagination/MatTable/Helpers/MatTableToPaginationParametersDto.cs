using Application.Core;
using Infraestructure.Crosscutting;
using Infrastructure.CrossCutting.Enums;

namespace Distributed.Core.Pagination.MatTable.Helpers
{
    public class MatTableToPaginationParametersDto<TDto> where TDto : class
    {
        public static PaginationParametersDto<TDto> Convert(MatTable matTable)
        {
            var searchableColumns = matTable.Columns.FindAll(p => p.Search == null || p.Search.Value);
            var filterParameterDto = new PaginationParametersDto<TDto>
            {
                Start = matTable.PageIndex * matTable.PageSize,
                AmountRows = matTable.PageSize,
                ColumnOrder = StringHelper.ToPascalCase(matTable.SortColumn),
                OrderType = matTable.SortDirection == "asc" ? OrderType.Ascending : OrderType.Descending,
                WhereFilter = LambdaManager.ConvertToLambda<TDto>(searchableColumns, matTable.Filter),
                CurrentPage = matTable.PageIndex
            };

            return filterParameterDto;
        }
    }
}
