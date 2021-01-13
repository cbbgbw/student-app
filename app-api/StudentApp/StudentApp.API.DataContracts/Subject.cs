using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.API.DataContracts
{
    public class Subject
    {
        public Guid SubjectKey { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        public string Description { get; set; }
        public Guid TypeDefinitionKey { get; set; }

        [Required]
        public bool IsPassed { get; set; }
        [Required]
        public bool HasProjectToPass { get; set; }

        [Required]
        public Guid SemesterDefinitionKey { get; set; }
        public bool isArchive { get; set; }
    }
}
