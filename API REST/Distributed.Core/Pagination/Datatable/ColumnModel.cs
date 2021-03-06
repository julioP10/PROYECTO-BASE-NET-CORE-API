namespace Distributed.Core.Pagination.Datatable
{
    public class ColumnModel
    {
        public string Data { get; set; }
        public string Name { get; set; }
        public bool Searchable { get; set; }
        public bool Orderable { get; set; }
        public SearchColumn Search { get; set; }
    }
}