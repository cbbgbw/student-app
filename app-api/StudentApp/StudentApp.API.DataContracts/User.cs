using System;
using System.ComponentModel.DataAnnotations;

namespace StudentApp.API.DataContracts
{
    /// <summary>
    /// User datacontract summary to be replaced
    /// </summary>
    public class User
    {
        public Guid UserKey { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoginName { get; set; }
        public string EmailAddress { get; set; }
        public Guid SemesterDefinitionGroupKey { get; set; }
    }
}
