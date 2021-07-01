using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject.Common.Interface
{
    public interface IPaging
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Skip { get; set; }
        public int TotalItemsCount { get; set; }
    }
}
