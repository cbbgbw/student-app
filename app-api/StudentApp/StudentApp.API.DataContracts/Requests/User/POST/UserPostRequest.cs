using System;
using StudentApp.API.DataContracts.Requests.User.POST;

namespace StudentApp.API.DataContracts.Requests.User.POST
{
    public class UserPostRequest
    {
        public DateTime Date { get; set; }

        public UserPost User { get; set; }
    }
}
