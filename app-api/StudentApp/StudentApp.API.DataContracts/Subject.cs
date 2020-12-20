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
        public Guid SubjectKEY { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required]
        public Guid CurrentSubjectStateKEY { get; set; }

        [Required]
        public bool HasProjectToPass { get; set; }

        [Required]
        public int Semester { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreateTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ModifyTime { get; set; }

        public bool isArchive { get; set; }
    }
}
