using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.API.DataContracts.Requests.Subject.PUT
{
    public class SubjectPutRequest
    {
        public DateTime Date { get; set; }
        public SubjectPut Subject { get; set; }
    }
}
