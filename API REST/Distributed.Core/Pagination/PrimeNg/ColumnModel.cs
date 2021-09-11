namespace Distributed.Core.Pagination.PrimeNg
{
    public class ColumnModel
    {
        public string Field { get; set; }
        public string Header { get; set; }
        public bool? Search { get; set; }
        public bool? Order { get; set; }
        public string Operation { get; set; }
    }
}