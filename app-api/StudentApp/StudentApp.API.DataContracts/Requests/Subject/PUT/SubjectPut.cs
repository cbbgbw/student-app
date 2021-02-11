using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.API.DataContracts.Requests.Subject.PUT
{
    public class SubjectPut
    {
        public Guid SubjectKey { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPassed { get; set; }
        public Guid TypeDefinitionKey { get; set; }
        public bool HasProjectToPass { get; set; }
        public Guid SemesterDefinitionKey { get; set; }
    }
}
