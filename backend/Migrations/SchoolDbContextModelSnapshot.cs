﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using backend.Data;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    partial class SchoolDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("backend.Data.Models.Student", b =>
                {
                    b.Property<int>("studentid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("studentid"));

                    b.Property<string>("studentname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("studentid");

                    b.ToTable("students");
                });

            modelBuilder.Entity("backend.Data.Models.Student_Subject", b =>
                {
                    b.Property<int>("studentsubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("studentsubjectId"));

                    b.Property<int>("studentid")
                        .HasColumnType("integer");

                    b.Property<int>("subjectid")
                        .HasColumnType("integer");

                    b.HasKey("studentsubjectId");

                    b.HasIndex("studentid");

                    b.HasIndex("subjectid");

                    b.ToTable("studentsubjects");
                });

            modelBuilder.Entity("backend.Data.Models.Subject", b =>
                {
                    b.Property<int>("subjectid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("subjectid"));

                    b.Property<string>("subjectname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("subjectid");

                    b.ToTable("subjects");
                });

            modelBuilder.Entity("backend.Data.Models.Student_Subject", b =>
                {
                    b.HasOne("backend.Data.Models.Student", "student")
                        .WithMany("studentsubject")
                        .HasForeignKey("studentid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Data.Models.Subject", "subject")
                        .WithMany("studentsubject")
                        .HasForeignKey("subjectid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("student");

                    b.Navigation("subject");
                });

            modelBuilder.Entity("backend.Data.Models.Student", b =>
                {
                    b.Navigation("studentsubject");
                });

            modelBuilder.Entity("backend.Data.Models.Subject", b =>
                {
                    b.Navigation("studentsubject");
                });
#pragma warning restore 612, 618
        }
    }
}