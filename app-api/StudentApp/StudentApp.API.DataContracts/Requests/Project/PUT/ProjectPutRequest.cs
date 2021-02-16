using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.API.DataContracts.Requests.Project.PUT
{
    public class ProjectPutRequest
    {
        public DateTime Date { get; set; }
        public ProjectPut Project { get; set; }
    }
}
