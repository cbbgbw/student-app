using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.API.DataContracts
{
    public class Event
    {
        public Guid EventKey { get; set; }
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        [Required]
        public Guid ProjectKey { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime SetTime { get; set; }
    }
}
