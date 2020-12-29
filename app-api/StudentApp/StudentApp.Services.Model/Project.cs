using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Services.Model
{
    public class Project
    {
        [Key]
        public Guid ProjectKey { get; set; }
        public string Name { get; set; }
        public Guid TypeDefinitionKey { get; set; }
        public Definition DefinitionType { get; set; }
        public string Description { get; set; }
        public DateTime DeadlineTime { get; set; }
        public bool NecessaryToPass { get; set; }
        public Guid CurrentProjectStateKey { get; set; }
        public Guid CategoryKey { get; set; }
        public Guid SubjectKey { get; set; }
        public Subject Subject { get; set; }
        public int Mark { get; set; }
        public Guid WorkingAreaKey { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
        public bool IsArchive { get; set; }
    }
}
