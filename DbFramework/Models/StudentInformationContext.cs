using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DbFramework.Models
{
    public partial class StudentInformationContext : DbContext
    {
        public virtual DbSet<BranchInformation> BranchInformation { get; set; }
        public virtual DbSet<CollegeInformation> CollegeInformation { get; set; }
        public virtual DbSet<InformationSource> InformationSource { get; set; }
        public virtual DbSet<PersonalInformation> PersonalInformation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"server=(localdb)\StudentInfo;Database=StudentInformation;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BranchInformation>(entity =>
            {
                entity.HasKey(e => e.BranchId);

                entity.Property(e => e.BranchId).ValueGeneratedNever();

                entity.Property(e => e.Address).HasColumnType("nchar(500)");

                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasColumnType("nchar(100)");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnType("nchar(100)");

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasColumnType("nchar(100)");
            });

            modelBuilder.Entity<CollegeInformation>(entity =>
            {
                entity.HasKey(e => e.CollegeId);

                entity.Property(e => e.CollegeId).ValueGeneratedNever();

                entity.Property(e => e.Address).HasColumnType("nchar(500)");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnType("nchar(100)");

                entity.Property(e => e.CollegeName)
                    .IsRequired()
                    .HasColumnType("nchar(100)");

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasColumnType("nchar(100)");
            });

            modelBuilder.Entity<InformationSource>(entity =>
            {
                entity.HasKey(e => e.InfoSourceId);

                entity.Property(e => e.InfoSourceId).ValueGeneratedNever();

                entity.Property(e => e.InfoSourceDescription)
                    .IsRequired()
                    .HasColumnType("nchar(200)");
            });

            modelBuilder.Entity<PersonalInformation>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.StudentId).ValueGeneratedNever();

                entity.Property(e => e.Address).HasColumnType("nchar(500)");

                entity.Property(e => e.BirthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasColumnType("nchar(100)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("nchar(100)");

                entity.Property(e => e.PassingYear).HasColumnType("nchar(10)");

                entity.Property(e => e.YearId)
                    .IsRequired()
                    .HasColumnType("nchar(10)");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.PersonalInformation)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonalI__Branc__5070F446");

                entity.HasOne(d => d.College)
                    .WithMany(p => p.PersonalInformation)
                    .HasForeignKey(d => d.CollegeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonalI__Colle__4F7CD00D");

                entity.HasOne(d => d.InfoSource)
                    .WithMany(p => p.PersonalInformation)
                    .HasForeignKey(d => d.InfoSourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonalI__InfoS__5441852A");
            });
        }
    }
}
