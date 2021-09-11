using System.Collections.Generic;

namespace Distributed.Core.Pagination.Datatable
{
    public class DataTableResponse<T> where T : class
    {
        public List<T> Data { get; set; }
        public int Draw { get; set; }
        public int RecordsFiltered { get; set; }
        public int RecordsTotal { get; set; }
    }
}