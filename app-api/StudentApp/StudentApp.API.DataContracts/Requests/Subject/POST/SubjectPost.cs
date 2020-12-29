using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.API.DataContracts.Requests.Subject.POST
{
    public class SubjectPost
    {
        public Guid SubjectKEY { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required]
        public bool HasProjectToPass { get; set; }

        [Required]
        public int Semester { get; set; }
    }
}
