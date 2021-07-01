using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject.Common.Interface
{
    public interface IFiltering
    {
        public string SearchBy { get; set; }
        public string Search { get; set; }
    }
}
