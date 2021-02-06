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
        public string Name { get; set; }
        public Guid TypeDefinitionKey { get; set; }
        public string TypeDefinitionName { get; set; }
        public string Description { get; set; }
        public DateTime DeadlineTime { get; set; }
        public bool NecessaryToPass { get; set; }
        public Guid ProjectStatusKey { get; set; }
        public string ProjectStatusName { get; set; }
        public Guid CategoryKey { get; set; }
        public string CategoryName { get; set; }
        public Guid SubjectKey { get; set; }
        public string SubjectTitle { get; set; }
        public int Mark { get; set; }
        //public Guid WorkingAreaKey { get; set; }
        //public DateTime CreateTime { get; set; }
        //public DateTime ModifyTime { get; set; }
        //public bool IsArchive { get; set; }

    }
}
