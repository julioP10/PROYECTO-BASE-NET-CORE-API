namespace Distributed.Core.Pagination.MatTable
{
    public class ColumnModel
    {
        public string Field { get; set; }
        public string Header { get; set; }
        public bool? Search { get; set; }
        public bool? Order { get; set; }
    }
}