using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.API.DataContracts.Requests.User
{
    public class UserAuthenticate
    {
        [Required]
        public string LoginName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
