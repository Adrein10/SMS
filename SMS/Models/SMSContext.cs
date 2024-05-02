using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SMS.Models
{
    public partial class SMSContext : DbContext
    {
        public SMSContext()
        {
        }

        public SMSContext(DbContextOptions<SMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentReg> StudentRegs { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("course");

                entity.Property(e => e.Courseid).HasColumnName("courseid");

                entity.Property(e => e.Coursefees).HasColumnName("coursefees");

                entity.Property(e => e.Coursename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("coursename");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<StudentReg>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.ToTable("StudentReg");

                entity.Property(e => e.StudentId).HasColumnName("studentId");

                entity.Property(e => e.Courseid).HasColumnName("courseid");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("startDate");

                entity.Property(e => e.StudentEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StudentRegs)
                    .HasForeignKey(d => d.Courseid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentRe__cours__5EBF139D");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
