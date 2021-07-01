using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject.Common.Interface
{
    public interface ISorting
    {
        public string SortOrder { get; set; }
        public string SortBy { get; set; }
    }
}
