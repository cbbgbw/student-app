using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S = StudentApp.Services.Model;

namespace StudentApp.Services.Responses.User
{
    public class UserResponse
    {
        public Guid UserKey { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoginName { get; set; }
        public string EmailAddress { get; set; }
        public Guid CurrentSemesterDefinitionKey { get; set; }

        public UserResponse(S.User user, Guid currentSemesterDefinitionKey)
        {
            UserKey = user.UserKey;
            FirstName = user.FirstName;
            LastName = user.LastName;
            LoginName = user.LoginName;
            EmailAddress = user.EmailAddress;
            CurrentSemesterDefinitionKey = currentSemesterDefinitionKey;
        }
    }
}
