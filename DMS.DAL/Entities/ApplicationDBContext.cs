using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DMS.DAL.Entities
{
    public partial class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentUser> StudentUsers { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;
        public virtual DbSet<TeacherUser> TeacherUsers { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;database=DMS_DB;user id=sa;password=5975;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Section)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.MinimumMarks).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalMarks).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__Course__ClassId__46E78A0C");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK__Course__TeacherI__47DBAE45");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.DoB).HasColumnType("datetime");

                entity.Property(e => e.FatherName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Grno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GRNo");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Picture).IsUnicode(false);

                entity.Property(e => e.PrimaryPhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SecondaryPhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__Student__ClassId__4CA06362");
            });

            modelBuilder.Entity<StudentUser>(entity =>
            {
                entity.ToTable("StudentUser");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentUsers)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__StudentUs__Stude__4F7CD00D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.StudentUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__StudentUs__UserI__5070F446");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.Cnic)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CNIC");

                entity.Property(e => e.DoB).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Picture).IsUnicode(false);

                entity.Property(e => e.PrimaryPhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SecondaryPhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TeacherUser>(entity =>
            {
                entity.ToTable("TeacherUser");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeacherUsers)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK__TeacherUs__Teach__412EB0B6");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TeacherUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__TeacherUs__UserI__4222D4EF");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.Email, "UQ__User__A9D1053420B8E89E")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
