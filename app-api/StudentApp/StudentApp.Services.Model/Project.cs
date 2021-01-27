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
        public string Description { get; set; }
        public DateTime DeadlineTime { get; set; }
        public bool NecessaryToPass { get; set; }
        public Guid ProjectStatusKey { get; set; }
        public Guid CategoryKey { get; set; }
        public Guid SubjectKey { get; set; }
        public int Mark { get; set; }
        public Guid WorkingAreaKey { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
        public bool IsArchive { get; set; }

        [ForeignKey("TypeDefinitionKey")]
        public Definition DefinitionType { get; set; }

        [ForeignKey("ProjectStatusKey")]
        public Status Status { get; set; }

        [ForeignKey("CategoryKey")]
        public Category Category { get; set; }

        [ForeignKey("SubjectKey")]
        public Subject Subject { get; set; }

        public ICollection<Event> ProjectEvents { get; set; }
    }
}
