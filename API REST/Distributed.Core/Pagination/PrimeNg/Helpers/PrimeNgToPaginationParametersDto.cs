using Application.Core;
using Infraestructure.Crosscutting;
using Infrastructure.CrossCutting.Enums;

namespace Distributed.Core.Pagination.PrimeNg.Helpers
{
    public class PrimeNgToPaginationParametersDto<TDto> where TDto : class
    {
        public static PaginationParametersDto<TDto> Convert(PrimeTable primeTable)
        {
            var searchableColumns = primeTable.Columns.FindAll(p => p.Search == null || p.Search.Value);
            var filterParameterDto = new PaginationParametersDto<TDto>
            {
                Start = primeTable.First,
                AmountRows = primeTable.Rows,
                ColumnOrder = StringHelper.ToPascalCase(primeTable.SortField),
                OrderType = (OrderType)(primeTable.SortOrder + 1),
                WhereFilter = LambdaManager.ConvertToLambda<TDto>(searchableColumns, primeTable.GlobalFilter),
                CurrentPage = (primeTable.First / primeTable.Rows)
            };

            return filterParameterDto;
        }
    }
}