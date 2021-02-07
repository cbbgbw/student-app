using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.API.DataContracts.Requests.Category.POST
{
    public class CategoryPostRequest
    {
        public DateTime Date { get; set; }
        public CategoryPost Category { get; set; }
    }
}
