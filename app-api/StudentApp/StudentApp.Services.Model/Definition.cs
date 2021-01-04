using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Services.Model
{
    public class Definition
    {
        [Key]
        public Guid DefinitionKey { get; set; }
        public Guid DefinitionGroupKey { get; set; }
        public string GroupName { get; set; }
        public string Value { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }

        //[ForeignKey("DefinitionGroupKey")]
        public DefinitionGroup DefinitionGroup { get; set; }
    }
}
