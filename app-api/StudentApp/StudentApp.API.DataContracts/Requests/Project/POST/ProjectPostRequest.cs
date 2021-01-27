using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentApp.API.DataContracts.Requests.Subject.POST;

namespace StudentApp.API.DataContracts.Requests.Project.POST
{
    public class ProjectPostRequest
    {
        public DateTime Date { get; set; }
        public ProjectPost Project { get; set; }
    }
}
