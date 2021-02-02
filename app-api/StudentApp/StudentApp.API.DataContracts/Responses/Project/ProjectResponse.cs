using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.API.DataContracts.Responses.Project
{
    public class ProjectResponse
    {
        public Guid ProjectKey { get; set; }
        public string ProjectType { get; set; }
        public string Description { get; set; }
        public DateTime DeadlineTime { get; set; }
        public bool NecessaryToPass { get; set; }
        public string CategoryName { get; set; }
        public Guid SubjectKey { get; set; }
        public string SubjectName { get; set; }

    }
}
