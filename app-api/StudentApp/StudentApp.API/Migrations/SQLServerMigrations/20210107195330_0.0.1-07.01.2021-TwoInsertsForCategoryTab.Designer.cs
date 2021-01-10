﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentApp.Tools.Configurations;

namespace StudentApp.API.Migrations.SQLServerMigrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210107195330_0.0.1-07.01.2021-TwoInsertsForCategoryTab")]
    partial class _00107012021TwoInsertsForCategoryTab
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("StudentApp.Services.Model.Category", b =>
                {
                    b.Property<Guid>("CategoryKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifyTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderIndex")
                        .HasColumnType("int");

                    b.Property<Guid>("ProjectTypeKey")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoryKey");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            CategoryKey = new Guid("8b79b0a3-83ba-4ca7-bdce-3aa035f224a6"),
                            CategoryName = "Odpowiedź ustna",
                            CreateTime = new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994),
                            ModifyTime = new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994),
                            OrderIndex = 1,
                            ProjectTypeKey = new Guid("00000000-0000-0000-0000-000000000022")
                        },
                        new
                        {
                            CategoryKey = new Guid("a695f015-326f-41b2-ae5a-c021cb8cc49f"),
                            CategoryName = "Kartkówka",
                            CreateTime = new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994),
                            ModifyTime = new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994),
                            OrderIndex = 2,
                            ProjectTypeKey = new Guid("00000000-0000-0000-0000-000000000022")
                        },
                        new
                        {
                            CategoryKey = new Guid("f2e2285b-faeb-4d09-88a3-390af93534e4"),
                            CategoryName = "Projekt zespołowy",
                            CreateTime = new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994),
                            ModifyTime = new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994),
                            OrderIndex = 1,
                            ProjectTypeKey = new Guid("00000000-0000-0000-0000-000000000012")
                        },
                        new
                        {
                            CategoryKey = new Guid("3eccbed0-4883-4e82-a1fe-832ffa0b52ee"),
                            CategoryName = "Projekt zaliczeniowy",
                            CreateTime = new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994),
                            ModifyTime = new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994),
                            OrderIndex = 2,
                            ProjectTypeKey = new Guid("00000000-0000-0000-0000-000000000012")
                        });
                });

            modelBuilder.Entity("StudentApp.Services.Model.Definition", b =>
                {
                    b.Property<Guid>("DefinitionKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DefinitionGroupKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifyTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DefinitionKey");

                    b.HasIndex("DefinitionGroupKey");

                    b.ToTable("Definition");

                    b.HasData(
                        new
                        {
                            DefinitionKey = new Guid("00000000-0000-0000-0000-000000000011"),
                            CreateTime = new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994),
                            DefinitionGroupKey = new Guid("00000000-0000-0000-0000-000000000001"),
                            GroupName = "SUBJECT_TYPES",
                            ModifyTime = new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994),
                            Value = "Laboratoria"
                        },
                        new
                        {
                            DefinitionKey = new Guid("00000000-0000-0000-0000-000000000021"),
                            CreateTime = new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994),
                            DefinitionGroupKey = new Guid("00000000-0000-0000-0000-000000000001"),
                            GroupName = "SUBJECT_TYPES",
                            ModifyTime = new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994),
                            Value = "Wykład"
                        },
                        new
                        {
                            DefinitionKey = new Guid("00000000-0000-0000-0000-000000000012"),
                            CreateTime = new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994),
                            DefinitionGroupKey = new Guid("00000000-0000-0000-0000-000000000002"),
                            GroupName = "PROJECT_TYPES",
                            ModifyTime = new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994),
                            Value = "Projekt"
                        },
                        new
                        {
                            DefinitionKey = new Guid("00000000-0000-0000-0000-000000000022"),
                            CreateTime = new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994),
                            DefinitionGroupKey = new Guid("00000000-0000-0000-0000-000000000002"),
                            GroupName = "PROJECT_TYPES",
                            ModifyTime = new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994),
                            Value = "Egzamin"
                        });
                });

            modelBuilder.Entity("StudentApp.Services.Model.DefinitionGroup", b =>
                {
                    b.Property<Guid>("DefinitionGroupKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifyTime")
                        .HasColumnType("datetime2");

                    b.HasKey("DefinitionGroupKey");

                    b.ToTable("DefinitionGroup");

                    b.HasData(
                        new
                        {
                            DefinitionGroupKey = new Guid("00000000-0000-0000-0000-000000000001"),
                            CreateTime = new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994),
                            Description = "Typ zajęć",
                            GroupName = "SUBJECT_TYPES",
                            ModifyTime = new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994)
                        },
                        new
                        {
                            DefinitionGroupKey = new Guid("00000000-0000-0000-0000-000000000002"),
                            CreateTime = new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994),
                            Description = "Typ projektu",
                            GroupName = "PROJECT_TYPES",
                            ModifyTime = new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994)
                        });
                });

            modelBuilder.Entity("StudentApp.Services.Model.Project", b =>
                {
                    b.Property<Guid>("ProjectKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeadlineTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsArchive")
                        .HasColumnType("bit");

                    b.Property<int>("Mark")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifyTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("NecessaryToPass")
                        .HasColumnType("bit");

                    b.Property<Guid>("ProjectStatusKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubjectKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TypeDefinitionKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WorkingAreaKey")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProjectKey");

                    b.HasIndex("CategoryKey");

                    b.HasIndex("ProjectStatusKey");

                    b.HasIndex("SubjectKey");

                    b.HasIndex("TypeDefinitionKey");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("StudentApp.Services.Model.Status", b =>
                {
                    b.Property<Guid>("StatusKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifyTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("StatusKey");

                    b.ToTable("Status");

                    b.HasData(
                        new
                        {
                            StatusKey = new Guid("00000000-0000-0000-0000-000000000001"),
                            Color = "ffffff",
                            CreateTime = new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994),
                            Description = "",
                            ModifyTime = new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994),
                            Name = "Nowy",
                            Type = 0
                        },
                        new
                        {
                            StatusKey = new Guid("00000000-0000-0000-0000-000000000002"),
                            Color = "ffffff",
                            CreateTime = new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994),
                            Description = "",
                            ModifyTime = new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994),
                            Name = "Otwarty",
                            Type = 1
                        },
                        new
                        {
                            StatusKey = new Guid("00000000-0000-0000-0000-000000000003"),
                            Color = "ffffff",
                            CreateTime = new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994),
                            Description = "",
                            ModifyTime = new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994),
                            Name = "W trakcie",
                            Type = 2
                        },
                        new
                        {
                            StatusKey = new Guid("00000000-0000-0000-0000-000000000004"),
                            Color = "ffffff",
                            CreateTime = new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994),
                            Description = "",
                            ModifyTime = new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994),
                            Name = "Wstrzymany",
                            Type = 3
                        },
                        new
                        {
                            StatusKey = new Guid("00000000-0000-0000-0000-000000000005"),
                            Color = "ffffff",
                            CreateTime = new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994),
                            Description = "",
                            ModifyTime = new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994),
                            Name = "Zakończony",
                            Type = 4
                        });
                });

            modelBuilder.Entity("StudentApp.Services.Model.Subject", b =>
                {
                    b.Property<Guid>("SubjectKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasProjectToPass")
                        .HasColumnType("bit");

                    b.Property<bool>("IsArchive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPassed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifyTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.Property<Guid>("TypeDefinitionKey")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SubjectKey");

                    b.HasIndex("TypeDefinitionKey");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("StudentApp.Services.Model.Definition", b =>
                {
                    b.HasOne("StudentApp.Services.Model.DefinitionGroup", "DefinitionGroup")
                        .WithMany("Definitions")
                        .HasForeignKey("DefinitionGroupKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DefinitionGroup");
                });

            modelBuilder.Entity("StudentApp.Services.Model.Project", b =>
                {
                    b.HasOne("StudentApp.Services.Model.Category", "Category")
                        .WithMany("Projects")
                        .HasForeignKey("CategoryKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentApp.Services.Model.Status", "Status")
                        .WithMany("Projects")
                        .HasForeignKey("ProjectStatusKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentApp.Services.Model.Subject", "Subject")
                        .WithMany("Projects")
                        .HasForeignKey("SubjectKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentApp.Services.Model.Definition", "DefinitionType")
                        .WithMany()
                        .HasForeignKey("TypeDefinitionKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("DefinitionType");

                    b.Navigation("Status");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("StudentApp.Services.Model.Subject", b =>
                {
                    b.HasOne("StudentApp.Services.Model.Definition", "StatusDefinition")
                        .WithMany()
                        .HasForeignKey("TypeDefinitionKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StatusDefinition");
                });

            modelBuilder.Entity("StudentApp.Services.Model.Category", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("StudentApp.Services.Model.DefinitionGroup", b =>
                {
                    b.Navigation("Definitions");
                });

            modelBuilder.Entity("StudentApp.Services.Model.Status", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("StudentApp.Services.Model.Subject", b =>
                {
                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
