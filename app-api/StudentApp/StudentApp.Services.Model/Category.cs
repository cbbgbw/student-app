using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string CategoryName { get; set; }
        public int OrderIndex { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
