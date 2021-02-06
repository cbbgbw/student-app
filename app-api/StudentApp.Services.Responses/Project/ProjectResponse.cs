using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentApp.Services.Responses.Project;
using S = StudentApp.Services.Model;

namespace StudentApp.Services.Responses.Project
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
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
        public bool IsArchive { get; set; }

        public ProjectResponse(S.Project project, string typeDefinitionName, string projectStatusName, string categoryName, string subjectTitle)
        {
            ProjectKey = project.ProjectKey;
            Name = project.Name;
            TypeDefinitionKey = project.TypeDefinitionKey;
            TypeDefinitionName = typeDefinitionName;
            Description = project.Description;
            DeadlineTime = project.DeadlineTime;
            NecessaryToPass = project.NecessaryToPass;
            ProjectStatusKey = project.ProjectStatusKey;
            ProjectStatusName = projectStatusName;
            CategoryKey = project.CategoryKey;
            CategoryName = categoryName;
            SubjectKey = project.SubjectKey;
            SubjectTitle = subjectTitle;
            Mark = project.Mark;
            CreateTime = project.CreateTime;
            ModifyTime = project.ModifyTime;
            IsArchive = project.IsArchive;
        }
    }
}
