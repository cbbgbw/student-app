﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
            DateTime date = DateTime.Now;
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


            /* Configuring realtions */
            modelBuilder.Entity<S.Definition>(entity =>
            {
                entity.HasOne(d => d.DefinitionGroup)
                    .WithMany(dg => dg.Definitions)
                    .HasForeignKey("DefinitionGroupKey");
            });


            modelBuilder.Entity<S.Definition>().HasData(new
            {
                DefinitionKey = Guid.Parse("00000000-0000-0000-0000-000000000011"),
                DefinitionGroupKey = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                GroupName = "SUBJECT_TYPES",
                Value = "Laboratoria",
                CreateTime = date,
                ModifyTime = date
            }, new
            {
                DefinitionKey = Guid.Parse("00000000-0000-0000-0000-000000000021"),
                DefinitionGroupKey = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                GroupName = "SUBJECT_TYPES",
                Value = "Wykład",
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

            /* II mig */
            modelBuilder.Entity<S.Definition>().HasData(new
            {
                DefinitionKey = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                DefinitionGroupKey = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                GroupName = "PROJECT_TYPES",
                Value = "Projekt",
                CreateTime = date,
                ModifyTime = date
            }, new
            {
                DefinitionKey = Guid.Parse("00000000-0000-0000-0000-000000000022"),
                DefinitionGroupKey = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                GroupName = "PROJECT_TYPES",
                Value = "Egzamin",
                CreateTime = date,
                ModifyTime = date
            });

            modelBuilder.Entity<S.Category>().HasData(new
            {
                CategoryKey = Guid.NewGuid(),
                ProjectTypeKey = Guid.Parse("00000000-0000-0000-0000-000000000022"),
                CategoryName = "Odpowiedź ustna",
                OrderIndex = 1,
                CreateTime = date,
                ModifyTime = date
            }, new
            {
                CategoryKey = Guid.NewGuid(),
                ProjectTypeKey = Guid.Parse("00000000-0000-0000-0000-000000000022"),
                CategoryName = "Kartkówka",
                OrderIndex = 2,
                CreateTime = date,
                ModifyTime = date
            });

            modelBuilder.Entity<S.Category>().HasData(new
            {
                CategoryKey = Guid.NewGuid(),
                ProjectTypeKey = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                CategoryName = "Projekt zespołowy",
                OrderIndex = 1,
                CreateTime = date,
                ModifyTime = date
            }, new
            {
                CategoryKey = Guid.NewGuid(),
                ProjectTypeKey = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                CategoryName = "Projekt zaliczeniowy",
                OrderIndex = 2,
                CreateTime = date,
                ModifyTime = date
            });
        }

        public DbSet<S.Subject> Subject { get; set; }
        public DbSet<S.Project> Project { get; set; }
        public DbSet<S.Definition> Definition { get; set; }
        public DbSet<S.Category> Category { get; set; }
        public DbSet<S.Status> Status { get; set; }
    }
}
