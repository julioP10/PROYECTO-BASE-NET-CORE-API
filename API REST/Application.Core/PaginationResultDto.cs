using System.Collections.Generic;

namespace Application.Core
{
    public class PaginationResultDto<T> where T : class
    {
        public int Count { get; set; }

        public IEnumerable<T> Entities { get; set; }
    }
}