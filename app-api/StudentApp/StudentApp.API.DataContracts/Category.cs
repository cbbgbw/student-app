using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.API.DataContracts
{
    public class Category
    {
        public Guid CategoryKey { get; set; }
        public Guid ProjectTypeKey { get; set; }
        public string CategoryName { get; set; }
        public int OrderIndex { get; set; }
    }
}
