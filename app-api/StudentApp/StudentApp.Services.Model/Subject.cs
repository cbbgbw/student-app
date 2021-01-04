using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Services.Model
{
    public class Subject
    {
        [Key]
        public Guid SubjectKey { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPassed { get; set; }
        public Guid TypeDefinitionKey { get; set; }
        public bool HasProjectToPass { get; set; }
        public int Semester { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
        public bool IsArchive { get; set; }

        [ForeignKey("TypeDefinitionKey")]
        public Definition StatusDefinition { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
