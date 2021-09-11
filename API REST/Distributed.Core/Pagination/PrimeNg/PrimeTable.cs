using System.Collections.Generic;

namespace Distributed.Core.Pagination.PrimeNg
{
    public class PrimeTable
    {
        public List<ColumnModel> Columns { get; set; }
        public int First { get; set; }
        public int Rows { get; set; }
        public string SortField { get; set; }
        public int SortOrder { get; set; }
        public string GlobalFilter { get; set; }
    }
}