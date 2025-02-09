using ApplicationCore.Entities;

namespace ApplicationCore.Models
{
    public class PaginatedResultSet<T> where T : class
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<T> Movies { get; set; }
    }
}
