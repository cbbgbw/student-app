using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Services.Responses.Project
{
    public class ProjectCountResponse
    {
        public Guid TypeDefinitionKey { get; set; }
        public string TypeName { get; set; }
        public int CountValue { get; set; }

        public ProjectCountResponse(Guid typeDefinitionKey, string typeName, int countValue)
        {
            TypeDefinitionKey = typeDefinitionKey;
            TypeName = typeName;
            CountValue = countValue;
        }
    }
}
