using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API_university_labor_exchange.Models;

public partial class UniversityLaborExchangeContext : DbContext
{
    public UniversityLaborExchangeContext()
    {
    }

    public UniversityLaborExchangeContext(DbContextOptions<UniversityLaborExchangeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Career> Careers { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<JobPosition> JobPositions { get; set; }

    public virtual DbSet<JobPositionsCareer> JobPositionsCareers { get; set; }

    public virtual DbSet<JobPostionsSkill> JobPostionsSkills { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentsJobPosition> StudentsJobPositions { get; set; }

    public virtual DbSet<StudentsSkill> StudentsSkills { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-RCO83TL;Database=university_labor_exchange;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Career>(entity =>
        {
            entity.HasKey(e => e.IdCarrer);

            entity.Property(e => e.IdCarrer).ValueGeneratedNever();
            entity.Property(e => e.Abbreviation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CareerType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StudyProgram)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Cuit);

            entity.Property(e => e.Cuit)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LegalAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PostalCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RecruiterEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RecruiterLastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RecruiterName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RecruiterPhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RecruiterPosition)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RecruiterRelWithCompany)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sector)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SocialReason)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TelephoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Web)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Companies)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Companies_Users");
        });

        modelBuilder.Entity<JobPosition>(entity =>
        {
            entity.HasKey(e => e.IdJobPosition);

            entity.Property(e => e.IdJobPosition).ValueGeneratedNever();
            entity.Property(e => e.BenefitsOfferedDetail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.FrameworkAgreement)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdCompany)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.JobDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.JobTitle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.JobType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.TentativeStartDate).HasColumnType("date");
            entity.Property(e => e.WorkDay)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCompanyNavigation).WithMany(p => p.JobPositions)
                .HasForeignKey(d => d.IdCompany)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobPositions_Companies");
        });

        modelBuilder.Entity<JobPositionsCareer>(entity =>
        {
            entity.HasKey(e => e.IdJobPositionsCareers);

            entity.ToTable("JobPositions_careers");

            entity.Property(e => e.IdJobPositionsCareers)
                .ValueGeneratedNever()
                .HasColumnName("Id_jobPositions_careers");

            entity.HasOne(d => d.IdCareerNavigation).WithMany(p => p.JobPositionsCareers)
                .HasForeignKey(d => d.IdCareer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobPositions_careers_Careers");

            entity.HasOne(d => d.IdJobPositionNavigation).WithMany(p => p.JobPositionsCareers)
                .HasForeignKey(d => d.IdJobPosition)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobPositions_careers_JobPositions");
        });

        modelBuilder.Entity<JobPostionsSkill>(entity =>
        {
            entity.HasKey(e => e.IdJobPositionsSkills);

            entity.ToTable("JobPostions_skills");

            entity.Property(e => e.IdJobPositionsSkills)
                .ValueGeneratedNever()
                .HasColumnName("Id_jobPositions_skills");
            entity.Property(e => e.SkillLevel)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdJobPositionNavigation).WithMany(p => p.JobPostionsSkills)
                .HasForeignKey(d => d.IdJobPosition)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobPostions_skills_JobPositions");

            entity.HasOne(d => d.IdSkillNavigation).WithMany(p => p.JobPostionsSkills)
                .HasForeignKey(d => d.IdSkill)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobPostions_skills_Skills");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.IdSkill);

            entity.Property(e => e.IdSkill).ValueGeneratedNever();
            entity.Property(e => e.SkillName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Legajo);

            entity.Property(e => e.Legajo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CivilStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cuil)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DocumentNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DocumentType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Flat)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GithubProfileUrl)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GithubProfileURL");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LinkedInProfileUrl)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LinkedInProfileURL");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Observations).IsUnicode(false);
            entity.Property(e => e.Province)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SecondaryDegree)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sex)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StudyProgram)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TelephoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Turn)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCarrerNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.IdCarrer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Students_Careers");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Students_Users");
        });

        modelBuilder.Entity<StudentsJobPosition>(entity =>
        {
            entity.HasKey(e => e.IdStudentJobPosition);

            entity.ToTable("Students_jobPositions");

            entity.Property(e => e.IdStudentJobPosition)
                .ValueGeneratedNever()
                .HasColumnName("IdStudent_JobPosition");
            entity.Property(e => e.Legajo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdJobPositionNavigation).WithMany(p => p.StudentsJobPositions)
                .HasForeignKey(d => d.IdJobPosition)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Students_jobPositions_JobPositions");

            entity.HasOne(d => d.LegajoNavigation).WithMany(p => p.StudentsJobPositions)
                .HasForeignKey(d => d.Legajo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Students_jobPositions_Students");
        });

        modelBuilder.Entity<StudentsSkill>(entity =>
        {
            entity.HasKey(e => e.IdStudentsSkills);

            entity.ToTable("Students_skills");

            entity.Property(e => e.IdStudentsSkills)
                .ValueGeneratedNever()
                .HasColumnName("Id_students_skills");
            entity.Property(e => e.Legajo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("legajo");
            entity.Property(e => e.SkillLevel)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdSkillNavigation).WithMany(p => p.StudentsSkills)
                .HasForeignKey(d => d.IdSkill)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Students_skills_Skills");

            entity.HasOne(d => d.LegajoNavigation).WithMany(p => p.StudentsSkills)
                .HasForeignKey(d => d.Legajo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Students_skills_Students");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK_Users_1");

            entity.Property(e => e.IdUser).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserType)
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
