using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LMS.Models.LMSModels
{
    public partial class Team31LMSContext : DbContext
    {
        public Team31LMSContext()
        {
        }

        public Team31LMSContext(DbContextOptions<Team31LMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admins> Admins { get; set; }
        public virtual DbSet<AssignmentCategories> AssignmentCategories { get; set; }
        public virtual DbSet<Assignments> Assignments { get; set; }
        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<EnrollmentGrades> EnrollmentGrades { get; set; }
        public virtual DbSet<Professors> Professors { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Submissions> Submissions { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=atr.eng.utah.edu;User Id=u0942147;Password=alekpass;Database=Team31LMS");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admins>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PRIMARY");

                entity.Property(e => e.UId)
                    .HasColumnName("uID")
                    .HasColumnType("char(8)");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.HasOne(d => d.U)
                    .WithOne(p => p.Admins)
                    .HasForeignKey<Admins>(d => d.UId)
                    .HasConstraintName("Admins_ibfk_1");
            });

            modelBuilder.Entity<AssignmentCategories>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.ClassId)
                    .HasName("classID");

                entity.HasIndex(e => new { e.Name, e.ClassId })
                    .HasName("classID_name")
                    .IsUnique();

                entity.Property(e => e.CategoryId).HasColumnName("categoryID");

                entity.Property(e => e.ClassId).HasColumnName("classID");

                entity.Property(e => e.GradingWeight).HasColumnName("grading_weight");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.AssignmentCategories)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("AssignmentCategories_ibfk_1");
            });

            modelBuilder.Entity<Assignments>(entity =>
            {
                entity.HasKey(e => e.AssignmentId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => new { e.CategoryId, e.Name })
                    .HasName("categoryID_name")
                    .IsUnique();

                entity.Property(e => e.AssignmentId).HasColumnName("assignmentID");

                entity.Property(e => e.CategoryId).HasColumnName("categoryID");

                entity.Property(e => e.Contents)
                    .IsRequired()
                    .HasColumnName("contents")
                    .HasColumnType("varchar(8192)");

                entity.Property(e => e.DueDate)
                    .HasColumnName("due_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.MaxPoints).HasColumnName("max_points");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Assignments_ibfk_1");
            });

            modelBuilder.Entity<Classes>(entity =>
            {
                entity.HasKey(e => e.ClassId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.UId)
                    .HasName("uID");

                entity.HasIndex(e => new { e.CourseId, e.Year, e.Season })
                    .HasName("Course_Semester")
                    .IsUnique();

                entity.Property(e => e.ClassId).HasColumnName("classID");

                entity.Property(e => e.CourseId).HasColumnName("courseID");

                entity.Property(e => e.EndTime)
                    .HasColumnName("end_time")
                    .HasColumnType("time");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnName("location")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Season)
                    .IsRequired()
                    .HasColumnName("season")
                    .HasColumnType("varchar(6)");

                entity.Property(e => e.StartTime)
                    .HasColumnName("start_time")
                    .HasColumnType("time");

                entity.Property(e => e.UId)
                    .IsRequired()
                    .HasColumnName("uID")
                    .HasColumnType("char(8)");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("Classes_ibfk_1");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.UId)
                    .HasConstraintName("Classes_ibfk_2");
            });

            modelBuilder.Entity<Courses>(entity =>
            {
                entity.HasKey(e => e.CourseId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => new { e.DeptAbbreviation, e.Number })
                    .HasName("subject_number")
                    .IsUnique();

                entity.Property(e => e.CourseId).HasColumnName("courseID");

                entity.Property(e => e.DeptAbbreviation)
                    .IsRequired()
                    .HasColumnName("dept_abbreviation")
                    .HasColumnType("varchar(4)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Number)
                    .HasColumnName("number")
                    .HasColumnType("int(4)");

                entity.HasOne(d => d.DeptAbbreviationNavigation)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.DeptAbbreviation)
                    .HasConstraintName("Courses_ibfk_1");
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.DeptAbbreviation)
                    .HasName("PRIMARY");

                entity.Property(e => e.DeptAbbreviation)
                    .HasColumnName("dept_abbreviation")
                    .HasColumnType("varchar(4)");

                entity.Property(e => e.DeptName)
                    .IsRequired()
                    .HasColumnName("dept_name")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<EnrollmentGrades>(entity =>
            {
                entity.HasKey(e => e.EnrollmentId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.ClassId)
                    .HasName("classID");

                entity.HasIndex(e => new { e.UId, e.ClassId })
                    .HasName("uID_classID")
                    .IsUnique();

                entity.Property(e => e.EnrollmentId).HasColumnName("enrollmentID");

                entity.Property(e => e.ClassId).HasColumnName("classID");

                entity.Property(e => e.Grade)
                    .IsRequired()
                    .HasColumnName("grade")
                    .HasColumnType("varchar(2)");

                entity.Property(e => e.UId)
                    .IsRequired()
                    .HasColumnName("uID")
                    .HasColumnType("char(8)");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.EnrollmentGrades)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EnrollmentGrades_ibfk_2");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.EnrollmentGrades)
                    .HasForeignKey(d => d.UId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EnrollmentGrades_ibfk_1");
            });

            modelBuilder.Entity<Professors>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.DeptAbbreviation)
                    .HasName("dept_abbreviation");

                entity.Property(e => e.UId)
                    .HasColumnName("uID")
                    .HasColumnType("char(8)");

                entity.Property(e => e.DeptAbbreviation)
                    .IsRequired()
                    .HasColumnName("dept_abbreviation")
                    .HasColumnType("varchar(4)");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.HasOne(d => d.DeptAbbreviationNavigation)
                    .WithMany(p => p.Professors)
                    .HasForeignKey(d => d.DeptAbbreviation)
                    .HasConstraintName("Professors_ibfk_1");

                entity.HasOne(d => d.U)
                    .WithOne(p => p.Professors)
                    .HasForeignKey<Professors>(d => d.UId)
                    .HasConstraintName("Professors_ibfk_2");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.DeptAbbreviation)
                    .HasName("dept_abbreviation");

                entity.Property(e => e.UId)
                    .HasColumnName("uID")
                    .HasColumnType("char(8)");

                entity.Property(e => e.DeptAbbreviation)
                    .IsRequired()
                    .HasColumnName("dept_abbreviation")
                    .HasColumnType("varchar(4)");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.HasOne(d => d.DeptAbbreviationNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.DeptAbbreviation)
                    .HasConstraintName("Students_ibfk_1");

                entity.HasOne(d => d.U)
                    .WithOne(p => p.Students)
                    .HasForeignKey<Students>(d => d.UId)
                    .HasConstraintName("Students_ibfk_2");
            });

            modelBuilder.Entity<Submissions>(entity =>
            {
                entity.HasKey(e => e.SubmissionId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.AssignmentId)
                    .HasName("assignmentID");

                entity.HasIndex(e => new { e.UId, e.AssignmentId })
                    .HasName("uid_assignmentID")
                    .IsUnique();

                entity.Property(e => e.SubmissionId).HasColumnName("submissionID");

                entity.Property(e => e.AssignmentId).HasColumnName("assignmentID");

                entity.Property(e => e.Contents)
                    .IsRequired()
                    .HasColumnName("contents")
                    .HasColumnType("varchar(8192)");

                entity.Property(e => e.Score).HasColumnName("score");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("time_stamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.UId)
                    .IsRequired()
                    .HasColumnName("uID")
                    .HasColumnType("char(8)");

                entity.HasOne(d => d.Assignment)
                    .WithMany(p => p.Submissions)
                    .HasForeignKey(d => d.AssignmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Submissions_ibfk_1");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.Submissions)
                    .HasForeignKey(d => d.UId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Submissions_ibfk_2");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PRIMARY");

                entity.Property(e => e.UId)
                    .HasColumnName("uID")
                    .HasColumnType("char(8)");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasColumnType("varchar(100)");
            });
        }
    }
}
