using MonoProject.Common.Interface;

namespace MonoProject.Common.Models
{
    public class Filtering : IFiltering
    {
        public Filtering(string searchBy, string search)
        {
            SearchBy = searchBy ?? "Name";
            Search = search ?? "";
        }
        public string SearchBy { get; set; }
        public string Search { get; set; }
    }
}
