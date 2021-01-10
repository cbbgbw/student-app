using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.API.DataContracts
{
    public class Project
    {
        public Guid ProjectKey { get; set; }

        [DataType(DataType.Text)]
        public string Name { get; set; }
        public Guid TypeDefinitionKey { get; set; }

        [DataType(DataType.Text)]
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DeadlineTime { get; set; }
        public bool NecessaryToPass { get; set; }
        public Guid ProjectStatusKey { get; set; }
        public Guid CategoryKey { get; set; }
        public Guid SubjectKey { get; set; }
        public int Mark { get; set; }
        public Guid WorkingAreaKey { get; set; }
        public bool IsArchive { get; set; }
    }
}
