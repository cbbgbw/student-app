using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Services.Model
{
    public class Category
    {
        [Key]
        public Guid CategoryKey { get; set; }
        public Guid ProjectTypeKey { get; set; }
        public Guid UserKey { get; set; }
        public string CategoryName { get; set; }
        public int OrderIndex { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }

        public ICollection<Project> Projects { get; set; }
        [ForeignKey(nameof(UserKey))]
        public User User { get; set; }
    }
}
