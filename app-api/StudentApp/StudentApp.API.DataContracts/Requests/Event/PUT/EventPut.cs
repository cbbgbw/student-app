using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.API.DataContracts.Requests.Event.PUT
{
    public class EventPut
    {
        public Guid EventKey { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime SetTime { get; set; }
    }
}
