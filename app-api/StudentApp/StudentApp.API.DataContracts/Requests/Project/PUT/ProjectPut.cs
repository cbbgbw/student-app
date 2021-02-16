using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.API.DataContracts.Requests.Project.PUT
{
    public class ProjectPut
    {
        public Guid ProjectKey { get; set; }
        public string Name { get; set; }
        public Guid TypeDefinitionKey { get; set; }
        public string Description { get; set; }
        public DateTime DeadlineTime { get; set; }
        public bool NecessaryToPass { get; set; }
        public Guid ProjectStatusKey { get; set; }
        public Guid CategoryKey { get; set; }
        public Guid SubjectKey { get; set; }
    }
}
