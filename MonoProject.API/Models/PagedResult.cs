using MonoProject.Common.Models;
using System.Collections.Generic;

namespace MonoProject.API.Models
{
    public class PagedResult<T> where T : class
    {
        public IEnumerable<T> Data { get; set; }
        public Filtering Filtering { get; set; }
        public Paging Pagination { get; set; }
        public Sorting Sorting { get; set; }
    }
}
