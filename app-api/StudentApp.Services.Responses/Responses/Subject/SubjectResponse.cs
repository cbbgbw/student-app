using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S = StudentApp.Services.Model;

namespace StudentApp.Services.Responses.Subject
{
    public class SubjectResponse
    {
        public Guid SubjectKey { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPassed { get; set; }
        public Guid TypeDefinitionKey { get; set; }
        public string TypeDefinitionName { get; set; }
        public bool HasProjectToPass { get; set; }
        public Guid SemesterDefinitionKey { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
        public bool IsArchive { get; set; }

        public SubjectResponse(S.Subject subject, string typeName)
        {
            SubjectKey = subject.SubjectKey;
            Name = subject.Name;
            Description = subject.Description;
            IsPassed = subject.IsPassed;
            TypeDefinitionKey = subject.TypeDefinitionKey;
            TypeDefinitionName = typeName;
            HasProjectToPass = subject.HasProjectToPass;
            SemesterDefinitionKey = subject.SemesterDefinitionKey;
            CreateTime = subject.CreateTime;
            ModifyTime = subject.ModifyTime;
            IsArchive = subject.IsArchive;
        }
    }
}
