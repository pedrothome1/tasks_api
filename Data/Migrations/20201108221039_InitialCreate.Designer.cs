﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tasks.Api.Data;

namespace Tasks.Api.Data.Migrations
{
    [DbContext(typeof(TasksDatabaseContext))]
    [Migration("20201108221039_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tasks.Api.Models.Assignment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estimate")
                        .HasColumnType("int");

                    b.Property<Guid?>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Project")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("Tasks.Api.Models.AssignmentGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AssignmentGroups");
                });

            modelBuilder.Entity("Tasks.Api.Models.AssignmentUnit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AssignmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("EndedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("StartedAt")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("AssignmentId");

                    b.ToTable("AssignmentUnits");
                });

            modelBuilder.Entity("Tasks.Api.Models.Assignment", b =>
                {
                    b.HasOne("Tasks.Api.Models.AssignmentGroup", "Group")
                        .WithMany("Assignments")
                        .HasForeignKey("GroupId");
                });

            modelBuilder.Entity("Tasks.Api.Models.AssignmentUnit", b =>
                {
                    b.HasOne("Tasks.Api.Models.Assignment", "Assignment")
                        .WithMany("Units")
                        .HasForeignKey("AssignmentId");
                });
#pragma warning restore 612, 618
        }
    }
}