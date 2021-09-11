using System.Collections.Generic;

namespace Distributed.Core.Pagination.Datatable
{
    public class GridTable
    {
        public int Draw { get; set; }
        public List<ColumnModel> Columns { get; set; }
        public List<OrderColumn> Order { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }

        //public List<ColumnInformation> Homologaciones { get; set; }
        public SearchColumn Search { get; set; }
    }
}