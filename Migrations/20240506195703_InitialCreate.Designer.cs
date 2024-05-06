﻿// <auto-generated />
using System;
using BolognaInformationSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BolognaInformationSystem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240506195703_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BolognaInformationSystem.Models.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseID"));

                    b.Property<int?>("AssignedInstructorID")
                        .HasColumnType("int");

                    b.Property<string>("CourseDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseID");

                    b.HasIndex("AssignedInstructorID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("BolognaInformationSystem.Models.LearningOutcome", b =>
                {
                    b.Property<int>("OutcomeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OutcomeID"));

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OutcomeID");

                    b.HasIndex("CourseID");

                    b.ToTable("LearningOutcomes");
                });

            modelBuilder.Entity("BolognaInformationSystem.Models.OutcomeRelation", b =>
                {
                    b.Property<int>("OutcomeID")
                        .HasColumnType("int");

                    b.Property<int>("ProgramOutcomeID")
                        .HasColumnType("int");

                    b.Property<int>("LearningOutcomeOutcomeID")
                        .HasColumnType("int");

                    b.Property<int>("RelationDegree")
                        .HasColumnType("int");

                    b.HasKey("OutcomeID", "ProgramOutcomeID");

                    b.HasIndex("LearningOutcomeOutcomeID");

                    b.HasIndex("ProgramOutcomeID");

                    b.ToTable("OutcomeRelations");
                });

            modelBuilder.Entity("BolognaInformationSystem.Models.ProgramOutcome", b =>
                {
                    b.Property<int>("ProgramOutcomeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProgramOutcomeID"));

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProgramOutcomeID");

                    b.ToTable("ProgramOutcomes");
                });

            modelBuilder.Entity("BolognaInformationSystem.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TCIdentityNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BolognaInformationSystem.Models.Course", b =>
                {
                    b.HasOne("BolognaInformationSystem.Models.User", "AssignedInstructor")
                        .WithMany()
                        .HasForeignKey("AssignedInstructorID");

                    b.Navigation("AssignedInstructor");
                });

            modelBuilder.Entity("BolognaInformationSystem.Models.LearningOutcome", b =>
                {
                    b.HasOne("BolognaInformationSystem.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("BolognaInformationSystem.Models.OutcomeRelation", b =>
                {
                    b.HasOne("BolognaInformationSystem.Models.LearningOutcome", "LearningOutcome")
                        .WithMany()
                        .HasForeignKey("LearningOutcomeOutcomeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BolognaInformationSystem.Models.ProgramOutcome", "ProgramOutcome")
                        .WithMany()
                        .HasForeignKey("ProgramOutcomeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LearningOutcome");

                    b.Navigation("ProgramOutcome");
                });
#pragma warning restore 612, 618
        }
    }
}
