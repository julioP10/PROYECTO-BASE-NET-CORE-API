using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Core.Pagination
{
    public interface IPaginationResult<T> where T : class
    {
        int Count { get; set; }
        IEnumerable<T> Entities { get; set; }
    }
}
