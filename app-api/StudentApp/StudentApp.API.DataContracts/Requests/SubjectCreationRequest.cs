using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.API.DataContracts.Requests
{
    public class SubjectCreationRequest
    {
        public DateTime Date { get; set; }
        public Subject Subject { get; set; }
    }
}
