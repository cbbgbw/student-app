using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SU = StudentApp.Services.Model;

namespace StudentApp.API.DataContracts.Responses.User
{
    public class AuthenticateResponse
    {
        public Guid UserKey { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoginName { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(SU.User user, string token)
        {
            UserKey = user.UserKey;
            FirstName = user.FirstName;
            LastName = user.LastName;
            LoginName = user.LoginName;
            Token = token;
        }
    }
}
