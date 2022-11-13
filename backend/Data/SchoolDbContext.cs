using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions options) : base(options)
        {

        } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student_Subject>()
                .HasOne(s => s.student)
                .WithMany(ss => ss.studentsubject)
                .HasForeignKey(si => si.studentid);

            modelBuilder.Entity<Student_Subject>()
                .HasOne(s => s.subject)
                .WithMany(ss => ss.studentsubject)
                .HasForeignKey(si => si.subjectid);
        }
        public DbSet<Student> students { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Student_Subject> studentsubjects { get; set; }
    }
}