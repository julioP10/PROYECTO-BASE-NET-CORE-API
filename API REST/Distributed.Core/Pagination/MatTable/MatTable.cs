using System;
using System.Collections.Generic;
using System.Text;

namespace Distributed.Core.Pagination.MatTable
{
    public class MatTable
    {
        public List<ColumnModel> Columns { get; set; }
        public string Filter { get; set; }
        public string SortColumn { get; set; }
        public string SortDirection { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
