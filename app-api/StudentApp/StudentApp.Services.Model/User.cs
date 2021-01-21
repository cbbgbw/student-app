
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentApp.Services.Model
{
    public class User
    {
        [Key]
        public Guid UserKey { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoginName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string EmailAddress { get; set; }
        public Guid SemesterDefinitionGroupKey { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }

        [ForeignKey(nameof(SemesterDefinitionGroupKey))]
        public DefinitionGroup SemesterDefinitionGroup { get; set; }
        
    }
}
