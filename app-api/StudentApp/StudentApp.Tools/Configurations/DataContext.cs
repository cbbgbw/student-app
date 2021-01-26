using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StudentApp.Tools.Helpers;
using S = StudentApp.Services.Model;

namespace StudentApp.Tools.Configurations
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* Entities configuration */
            modelBuilder.Entity<S.User>(entity =>
            {
                entity.HasOne(d => d.SemesterDefinitionGroup)
                    .WithOne(e => e.UserSemesterDefinitionGroup)
                    .OnDelete(DeleteBehavior.ClientNoAction);

                entity.HasMany(d => d.Categories)
                    .WithOne(e => e.User)
                    .OnDelete(DeleteBehavior.ClientNoAction);
            });

            modelBuilder.Entity<S.Subject>(entity =>
            {
                entity.HasOne(d => d.SemesterDefinition)
                    .WithMany(e => e.SubjectSemesterDefinitions)
                    .OnDelete(DeleteBehavior.ClientNoAction)
                    .HasForeignKey(d => d.SemesterDefinitionKey);

                entity.HasOne(d => d.StatusDefinition)
                    .WithMany(e => e.SubjectStatusDefinitions)
                    .OnDelete(DeleteBehavior.ClientNoAction)
                    .HasForeignKey(d => d.TypeDefinitionKey);

                entity.HasMany(d => d.Projects)
                    .WithOne(e => e.Subject)
                    .OnDelete(DeleteBehavior.ClientNoAction);
            });

            modelBuilder.Entity<S.Project>(entity =>
            {
                entity.HasOne(d => d.Subject)
                    .WithMany(e => e.Projects)
                    .OnDelete(DeleteBehavior.ClientNoAction);

                entity.HasOne(d => d.DefinitionType)
                    .WithMany(e => e.ProjectStatusDefinitions)
                    .OnDelete(DeleteBehavior.ClientNoAction);

                entity.HasOne(d => d.Category)
                    .WithMany(e => e.Projects)
                    .OnDelete(DeleteBehavior.ClientNoAction);

                entity.HasOne(d => d.Status)
                    .WithMany(e => e.Projects)
                    .OnDelete(DeleteBehavior.ClientNoAction);

                entity.HasMany(d => d.ProjectEvents)
                    .WithOne(e => e.Project)
                    .OnDelete(DeleteBehavior.ClientNoAction);
                entity.Property(e => e.ProjectStatusKey)
                    .HasDefaultValue(Guid.Parse("00000000-0000-0000-0000-000000000001"));

            });

            modelBuilder.Entity<S.Event>(entity =>
            {
                entity.HasOne(d => d.Project)
                    .WithMany(e => e.ProjectEvents)
                    .OnDelete(DeleteBehavior.ClientNoAction);
            });

            modelBuilder.Entity<S.DefinitionGroup>(entity =>
            {
                entity.HasMany(d => d.Definitions)
                    .WithOne(e => e.DefinitionGroup)
                    .OnDelete(DeleteBehavior.ClientNoAction);

                entity.HasOne(d => d.UserSemesterDefinitionGroup)
                    .WithOne(e => e.SemesterDefinitionGroup)
                    .OnDelete(DeleteBehavior.ClientNoAction);
            });

            modelBuilder.Entity<S.Definition>(entity =>
            {
                entity.HasOne(d => d.DefinitionGroup)
                    .WithMany(e => e.Definitions)
                    .OnDelete(DeleteBehavior.ClientNoAction);

                entity.HasMany(d => d.SubjectSemesterDefinitions)
                    .WithOne(e => e.SemesterDefinition)
                    .OnDelete(DeleteBehavior.ClientNoAction);

                entity.HasMany(d => d.SubjectStatusDefinitions)
                    .WithOne(e => e.StatusDefinition)
                    .OnDelete(DeleteBehavior.ClientNoAction);

                entity.HasMany(d => d.ProjectStatusDefinitions)
                    .WithOne(e => e.DefinitionType)
                    .OnDelete(DeleteBehavior.ClientNoAction);
            });

            modelBuilder.Entity<S.Category>(entity =>
            {
                entity.HasMany(d => d.Projects)
                    .WithOne(e => e.Category)
                    .OnDelete(DeleteBehavior.ClientNoAction);

                entity.HasOne(d => d.User)
                    .WithMany(e => e.Categories)
                    .OnDelete(DeleteBehavior.ClientNoAction);
            });

            modelBuilder.Entity<S.Status>(entity =>
            {
                entity.HasMany(d => d.Projects)
                    .WithOne(e => e.Status)
                    .OnDelete(DeleteBehavior.ClientNoAction);
            });

            
            

            
            /* Data inserting */
            DateTime date = new DateTime(2021, 1, 1);
            modelBuilder.Entity<S.Status>().HasData(new S.Status[]
            {
                new S.Status {StatusKey = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "Nowy", Description = "", Type = 0, Color = "ffffff", CreateTime = date, ModifyTime = date},
                new S.Status {StatusKey = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Otwarty", Description = "", Type = 1, Color = "ffffff", CreateTime = date, ModifyTime = date},
                new S.Status {StatusKey = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "W trakcie", Description = "", Type = 2, Color = "ffffff", CreateTime = date, ModifyTime = date},
                new S.Status {StatusKey = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "Wstrzymany", Description = "", Type = 3, Color = "ffffff", CreateTime = date, ModifyTime = date},
                new S.Status {StatusKey = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Zakończony", Description = "", Type = 4, Color = "ffffff", CreateTime = date, ModifyTime = date}
            });

            modelBuilder.Entity<S.DefinitionGroup>().HasData(
                new S.DefinitionGroup
                {
                    DefinitionGroupKey = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Description = "Typ zajęć",
                    GroupName = "SUBJECT_TYPES",
                    CreateTime = date,
                    ModifyTime = date
            });

            modelBuilder.Entity<S.Definition>().HasData(new
            {
                DefinitionKey = Guid.Parse("00000000-0000-0000-0000-000000000011"),
                DefinitionGroupKey = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                GroupName = "SUBJECT_TYPES",
                Value = "Laboratoria",
                Default = false,
                CreateTime = date,
                ModifyTime = date
            }, new
            {
                DefinitionKey = Guid.Parse("00000000-0000-0000-0000-000000000021"),
                DefinitionGroupKey = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                GroupName = "SUBJECT_TYPES",
                Value = "Wykład",
                Default = false,
                CreateTime = date,
                ModifyTime = date
            });


            modelBuilder.Entity<S.DefinitionGroup>().HasData(
                new S.DefinitionGroup
                {
                    DefinitionGroupKey = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    Description = "Typ projektu",
                    GroupName = "PROJECT_TYPES",
                    CreateTime = date,
                    ModifyTime = date
                });

            modelBuilder.Entity<S.Definition>().HasData(new S.Definition()
            {
                DefinitionKey = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                DefinitionGroupKey = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                GroupName = "PROJECT_TYPES",
                Value = "Projekt",
                Default = false,
                CreateTime = date,
                ModifyTime = date
            }, new S.Definition()
            {
                DefinitionKey = Guid.Parse("00000000-0000-0000-0000-000000000022"),
                DefinitionGroupKey = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                GroupName = "PROJECT_TYPES",
                Value = "Egzamin",
                Default = false,
                CreateTime = date,
                ModifyTime = date
            });

            modelBuilder.Entity<S.Category>().HasData(new S.Category()
            {
                CategoryKey = Guid.Parse("9A684681-FFAC-42E6-97A5-C07FB18E2A32"),
                ProjectTypeKey = Guid.Parse("00000000-0000-0000-0000-000000000022"),
                UserKey = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                CategoryName = "Odpowiedź ustna",
                OrderIndex = 1,
                CreateTime = date,
                ModifyTime = date
            }, new S.Category()
            {
                CategoryKey = Guid.Parse("C94DE30C-A03A-4432-91A1-310ACE86050A"),
                ProjectTypeKey = Guid.Parse("00000000-0000-0000-0000-000000000022"),
                UserKey = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                CategoryName = "Kartkówka",
                OrderIndex = 2,
                CreateTime = date,
                ModifyTime = date
            });

            modelBuilder.Entity<S.Category>().HasData(new S.Category()
            {
                CategoryKey = Guid.Parse("27FD71BF-F9E1-4293-A494-BE76B477C706"),
                ProjectTypeKey = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                UserKey = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                CategoryName = "Projekt zespołowy",
                OrderIndex = 1,
                CreateTime = date,
                ModifyTime = date
            }, new
            {
                CategoryKey = Guid.Parse("9969B359-B888-4D07-8E0A-F79234F58ADB"),
                ProjectTypeKey = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                UserKey = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                CategoryName = "Projekt zaliczeniowy",
                OrderIndex = 2,
                CreateTime = date,
                ModifyTime = date
            });


            /* User admin creating */
            Guid userDefinitionGroupKey = Guid.Parse("BDFC4999-EA15-4AEF-816F-DF1D0AB501EE");
            string userLoginName = "admin";

            Guid user2DefinitionGroupKey = Guid.Parse("CE1C4999-EA15-4AEF-816F-DF1D0AB501EE");
            string user2LoginName = "admin-front";

            modelBuilder.Entity<S.DefinitionGroup>().HasData(
                new S.DefinitionGroup
                {
                    DefinitionGroupKey = userDefinitionGroupKey,
                    Description = "Semestr użytkownika " + userLoginName,
                    GroupName = userLoginName + "_SEMESTERS",
                    CreateTime = date,
                    ModifyTime = date
                },
                new S.DefinitionGroup
                {
                    DefinitionGroupKey = user2DefinitionGroupKey,
                    Description = "Semestr użytkownika " + user2LoginName,
                    GroupName = user2LoginName + "_SEMESTERS",
                    CreateTime = date,
                    ModifyTime = date
                });

            modelBuilder.Entity<S.Definition>().HasData(new
            {
                DefinitionKey = Guid.Parse("C7EFFBB1-77C8-4B99-824E-D3DCD985C8C8"),
                DefinitionGroupKey = userDefinitionGroupKey,
                GroupName = userLoginName + "_SEMESTERS",
                Value = "1",
                Default = true,
                CreateTime = date,
                ModifyTime = date
            }, new
            {
                DefinitionKey = Guid.Parse("9F7116DF-AE43-49E9-9144-99A299E38FD5"),
                DefinitionGroupKey = userDefinitionGroupKey,
                GroupName = userLoginName + "_SEMESTERS",
                Value = "2",
                Default = false,
                CreateTime = date,
                ModifyTime = date
            }, new
            {
                DefinitionKey = Guid.Parse("5331B1C1-3BDB-4A06-8150-C3EB56A5364F"),
                DefinitionGroupKey = userDefinitionGroupKey,
                GroupName = userLoginName + "_SEMESTERS",
                Value = "3",
                Default = false,
                CreateTime = date,
                ModifyTime = date
            });

            /* System users */
            byte[] passwordHash, passwordSalt;
            string password = "cyberbug2021";
            PasswordHash.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            modelBuilder.Entity<S.User>().HasData(
                new S.User
                {
                    UserKey = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    FirstName = "admin",
                    LastName = "",
                    LoginName = userLoginName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    EmailAddress = "",
                    SemesterDefinitionGroupKey = userDefinitionGroupKey,
                    CreateTime = date,
                    ModifyTime = date,

                },
                new S.User
                {
                    UserKey = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    FirstName = "admin-front",
                    LastName = "",
                    LoginName = user2LoginName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    EmailAddress = "",
                    SemesterDefinitionGroupKey = user2DefinitionGroupKey,
                    CreateTime = date,
                    ModifyTime = date,

                });
        }

        public virtual DbSet<S.User> User { get; set; }
        public virtual DbSet<S.Subject> Subject { get; set; }
        public virtual DbSet<S.Project> Project { get; set; }
        public virtual DbSet<S.Event> Event { get; set; }
        public virtual DbSet<S.Definition> Definition { get; set; }
        public virtual DbSet<S.DefinitionGroup> DefinitionGroup { get; set; }
        public virtual DbSet<S.Category> Category { get; set; }
        public virtual DbSet<S.Status> Status { get; set; }
    }
}
