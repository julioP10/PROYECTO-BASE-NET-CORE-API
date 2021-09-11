using Domain.Core.Pagination;
using System.Collections.Generic;
using System.Linq;

namespace Infraestructure.Data.Core.Pagination
{
    public class PaginationResult<T> : IPaginationResult<T> 
        where T : class
    {
        public int Count { get; set; }

        public IEnumerable<T> Entities { get; set; }
    }
}