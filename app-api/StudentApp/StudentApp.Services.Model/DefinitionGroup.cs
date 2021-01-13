using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Services.Model
{
    public class DefinitionGroup
    {
        [Key]
        public Guid DefinitionGroupKey { get; set; }
        public string Description { get; set; }
        public string GroupName { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }

        public virtual ICollection<Definition> Definitions { get; set; }
        public User SemesterDefinitionGroup { get; set; }
    }
}
