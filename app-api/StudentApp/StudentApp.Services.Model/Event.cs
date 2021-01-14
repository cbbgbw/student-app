using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Services.Model
{
    public class Event
    {
        [Key]
        public Guid EventKey { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid ProjectKey { get; set; }
        public DateTime SetTime { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
        public bool IsArchive { get; set; }

        [ForeignKey(nameof(ProjectKey))]
        public Project Project { get; set; }
    }
}
