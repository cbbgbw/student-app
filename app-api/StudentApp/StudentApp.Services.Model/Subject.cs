using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Services.Model
{
    public class Subject
    {
        public Guid SubjectKEY { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CurrentSubjectStateKEY { get; set; }
        public bool HasProjectToPass { get; set; }
        public int Semester { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
        public bool isArchive { get; set; }
    }
}
