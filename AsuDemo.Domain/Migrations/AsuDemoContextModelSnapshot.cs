﻿// <auto-generated />
using System;
using AsuDemo.Domain.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AsuDemo.Domain.Migrations
{
    [DbContext(typeof(AsuDemoContext))]
    partial class AsuDemoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AsuDemo.Domain.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("PrerequisiteCourseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PrerequisiteCourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("AsuDemo.Domain.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("AsuDemo.Domain.Entities.DepartmentCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("DepartmentCourses");
                });

            modelBuilder.Entity("AsuDemo.Domain.Entities.Course", b =>
                {
                    b.HasOne("AsuDemo.Domain.Entities.Course", "PrerequisiteCourse")
                        .WithMany()
                        .HasForeignKey("PrerequisiteCourseId");

                    b.Navigation("PrerequisiteCourse");
                });

            modelBuilder.Entity("AsuDemo.Domain.Entities.DepartmentCourse", b =>
                {
                    b.HasOne("AsuDemo.Domain.Entities.Course", "Course")
                        .WithMany("DepartmentCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AsuDemo.Domain.Entities.Department", "Department")
                        .WithMany("DepartmentCourses")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("AsuDemo.Domain.Entities.Course", b =>
                {
                    b.Navigation("DepartmentCourses");
                });

            modelBuilder.Entity("AsuDemo.Domain.Entities.Department", b =>
                {
                    b.Navigation("DepartmentCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
