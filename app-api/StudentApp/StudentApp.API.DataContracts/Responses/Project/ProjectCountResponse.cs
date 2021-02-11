using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.API.DataContracts.Responses.Project
{
    public class ProjectCountResponse
    {
        public Guid TypeDefinitionKey { get; set; }
        public string TypeName { get; set; }
        public int CountValue { get; set; }
    }
}
