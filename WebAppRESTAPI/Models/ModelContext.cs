using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAppRESTAPI.Models
{
    public partial class ModelContext : DbContext
    {
        public virtual DbSet<Dept> Dept { get; set; }
        public virtual DbSet<Emp> Emp { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseOracle("User Id=scott;Password=tiger;Server=192.168.60.11;Direct=True;Sid=DB05;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dept>(entity =>
            {
                entity.HasKey(e => e.Deptno);

                entity.ToTable("DEPT", "SCOTT");

                entity.HasIndex(e => e.Deptno)
                    .HasName("PK_DEPT")
                    .IsUnique();

                entity.Property(e => e.Deptno).HasColumnName("DEPTNO");

                entity.Property(e => e.Dname)
                    .HasColumnName("DNAME")
                    .HasColumnType("varchar2")
                    .HasMaxLength(14);

                entity.Property(e => e.Loc)
                    .HasColumnName("LOC")
                    .HasColumnType("varchar2")
                    .HasMaxLength(13);
            });

            modelBuilder.Entity<Emp>(entity =>
            {
                entity.HasKey(e => e.Empno);

                entity.ToTable("EMP", "SCOTT");

                entity.HasIndex(e => e.Empno)
                    .HasName("PK_EMP")
                    .IsUnique();

                entity.Property(e => e.Empno).HasColumnName("EMPNO");

                entity.Property(e => e.Comm)
                    .HasColumnName("COMM")
                    .HasColumnType("double");

                entity.Property(e => e.Deptno).HasColumnName("DEPTNO");

                entity.Property(e => e.Ename)
                    .HasColumnName("ENAME")
                    .HasColumnType("varchar2")
                    .HasMaxLength(10);

                entity.Property(e => e.Hiredate)
                    .HasColumnName("HIREDATE")
                    .HasColumnType("date");

                entity.Property(e => e.Job)
                    .HasColumnName("JOB")
                    .HasColumnType("varchar2")
                    .HasMaxLength(9);

                entity.Property(e => e.Mgr).HasColumnName("MGR");

                entity.Property(e => e.Sal)
                    .HasColumnName("SAL")
                    .HasColumnType("double");

                //entity.HasOne(d => d.DeptnoNavigation)
                //    .WithMany(p => p.Emp)
                //    .HasForeignKey(d => d.Deptno)
                //    .HasConstraintName("FK_DEPTNO");
            });
        }
    }
}
