// <auto-generated />
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

            modelBuilder.Entity("backend.Data.Models.Marks", b =>
                {
                    b.Property<int>("marksid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("marksid"));

                    b.Property<string>("marks")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("studentid")
                        .HasColumnType("integer");

                    b.Property<int>("subjectid")
                        .HasColumnType("integer");

                    b.HasKey("marksid");

                    b.HasIndex("studentid");

                    b.HasIndex("subjectid");

                    b.ToTable("marks");
                });

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
                    b.Property<int>("studentsubjectid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("studentsubjectid"));

                    b.Property<int>("studentid")
                        .HasColumnType("integer");

                    b.Property<int>("subjectid")
                        .HasColumnType("integer");

                    b.HasKey("studentsubjectid");

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

            modelBuilder.Entity("backend.Data.Models.Marks", b =>
                {
                    b.HasOne("backend.Data.Models.Student", "student")
                        .WithMany()
                        .HasForeignKey("studentid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Data.Models.Subject", "subject")
                        .WithMany()
                        .HasForeignKey("subjectid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("student");

                    b.Navigation("subject");
                });

            modelBuilder.Entity("backend.Data.Models.Student_Subject", b =>
                {
                    b.HasOne("backend.Data.Models.Student", "student")
                        .WithMany()
                        .HasForeignKey("studentid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Data.Models.Subject", "subject")
                        .WithMany()
                        .HasForeignKey("subjectid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("student");

                    b.Navigation("subject");
                });
#pragma warning restore 612, 618
        }
    }
}
