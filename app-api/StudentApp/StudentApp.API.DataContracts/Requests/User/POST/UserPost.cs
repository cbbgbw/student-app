using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.API.DataContracts.Requests.User.POST
{
    public class UserPost
    {
        public Guid UserKey { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
    }
}
