using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SharedObjects.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISkillMatrix.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
: base(options)
        {

        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Result> Result { get; set; }
        public virtual DbSet<Sector> Sector { get; set; }
        public virtual DbSet<SkillMatrixContent> SkillMatrixContent { get; set; }
        public virtual DbQuery<VEmployee> VEmployee { get; set; }
        public virtual DbQuery<VSearchResult> VSearchResult { get; set; }
        public virtual DbQuery<VScore> VScore { get; set; }
        public virtual DbQuery<VSkillMatrix> VSkillMatrix { get; set; }
        public virtual DbQuery<VSector> VSector { get; set; }
        public virtual DbQuery<VResult> VResult { get; set; }
        
        public virtual DbQuery<VTopicByTrainer> VTopicByTrainer { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Sap);

                entity.HasIndex(e => e.Workcell);

                entity.Property(e => e.Sap)
                    .HasColumnName("SAP")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Position)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SuperiorEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Workcell)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.Property(e => e.Sap)
                    .HasColumnName("SAP")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sector>(entity =>
            {
                entity.Property(e => e.Sector1)
                    .HasColumnName("Sector")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SkillMatrixContent>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=HCMNBTE058;Initial Catalog=SkillMatrix;User Id=vui;Password=Zxcvbnm123;MultipleActiveResultSets=true;");
            }
        }
    }
}
