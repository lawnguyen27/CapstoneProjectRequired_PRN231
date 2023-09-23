using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BusinessObjects
{
    public partial class CapstoneProjectRequiredContext : DbContext
    {
        public CapstoneProjectRequiredContext()
        {
        }

        public CapstoneProjectRequiredContext(DbContextOptions<CapstoneProjectRequiredContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<GroupProject> GroupProjects { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Semester> Semesters { get; set; } = null!;
        public virtual DbSet<Specialization> Specializations { get; set; } = null!;
        public virtual DbSet<StudentInGroup> StudentInGroups { get; set; } = null!;
        public virtual DbSet<StudentInSemester> StudentInSemesters { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<Topic> Topics { get; set; } = null!;
        public virtual DbSet<TopicOfLecturer> TopicOfLecturers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }
        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            var strConn = config["ConnectionStrings:CapstoneProjectRequiredDB"];
            return strConn;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Avatar).IsUnicode(false);

                entity.Property(e => e.Code)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Account__RoleId__31EC6D26");
            });

            modelBuilder.Entity<GroupProject>(entity =>
            {
                entity.ToTable("GroupProject");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.GroupProjects)
                    .HasForeignKey(d => d.SemesterId)
                    .HasConstraintName("FK__GroupProj__Semes__2C3393D0");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.GroupProjects)
                    .HasForeignKey(d => d.TopicId)
                    .HasConstraintName("FK__GroupProj__Topic__2D27B809");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.ToTable("Semester");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<Specialization>(entity =>
            {
                entity.ToTable("Specialization");

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<StudentInGroup>(entity =>
            {
                entity.ToTable("StudentInGroup");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.JoinDate).HasColumnType("date");

                entity.Property(e => e.Role).HasMaxLength(20);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.StudentInGroups)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK__StudentIn__Group__34C8D9D1");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentInGroups)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__StudentIn__Stude__35BCFE0A");
            });

            modelBuilder.Entity<StudentInSemester>(entity =>
            {
                entity.ToTable("StudentInSemester");

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.StudentInSemesters)
                    .HasForeignKey(d => d.SemesterId)
                    .HasConstraintName("FK__StudentIn__Semes__3D5E1FD2");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentInSemesters)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__StudentIn__Stude__3B75D760");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.StudentInSemesters)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__StudentIn__Subje__3C69FB99");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.IsPrerequisite).HasColumnName("isPrerequisite");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Specialization)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.SpecializationId)
                    .HasConstraintName("FK__Subject__Special__38996AB5");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("Topic");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Topics)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK__Topic__GroupId__4222D4EF");

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.Topics)
                    .HasForeignKey(d => d.SemesterId)
                    .HasConstraintName("FK__Topic__SemesterI__286302EC");

                entity.HasOne(d => d.Specialization)
                    .WithMany(p => p.Topics)
                    .HasForeignKey(d => d.SpecializationId)
                    .HasConstraintName("FK__Topic__Specializ__29572725");
            });

            modelBuilder.Entity<TopicOfLecturer>(entity =>
            {
                entity.ToTable("TopicOfLecturer");

                entity.Property(e => e.IsSuperLecturer).HasColumnName("isSuperLecturer");

                entity.HasOne(d => d.Lecturer)
                    .WithMany(p => p.TopicOfLecturers)
                    .HasForeignKey(d => d.LecturerId)
                    .HasConstraintName("FK__TopicOfLe__Lectu__403A8C7D");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.TopicOfLecturers)
                    .HasForeignKey(d => d.TopicId)
                    .HasConstraintName("FK__TopicOfLe__Topic__412EB0B6");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
