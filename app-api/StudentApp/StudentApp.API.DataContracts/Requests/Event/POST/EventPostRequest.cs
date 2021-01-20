using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.API.DataContracts.Requests.Event.POST
{
    public class EventPostRequest
    {
        public DateTime Date { get; set; }
        public EventPost Event { get; set; }
    }
}
