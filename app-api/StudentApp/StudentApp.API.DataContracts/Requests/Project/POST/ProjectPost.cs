using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.API.DataContracts.Requests.Project.POST
{
    public class ProjectPost
    {
        public Guid ProjectKey { get; set; }
        [Required]
        public string Name { get; set; }
        //public Guid TypeDefinitionKey { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime DeadlineTime { get; set; }
        public bool NecessaryToPass { get; set; }
        //public Guid CurrentProjectStateKey { get; set; }
        //public Guid CategoryKey { get; set; }
        public Guid SubjectKey { get; set; }
        public int Mark { get; set; }
        //public Guid WorkingAreaKey { get; set; }
        public bool IsArchive { get; set; }
    }
}
