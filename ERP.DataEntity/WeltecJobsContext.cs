using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ERP.DataEntity;

public partial class WeltecJobsContext : DbContext
{
    public WeltecJobsContext()
    {
    }

    public WeltecJobsContext(DbContextOptions<WeltecJobsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserRegistrectionTbl> UserRegistrectionTbls { get; set; }

    public virtual DbSet<UserRoleTbl> UserRoleTbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-1B2K66Q1;Database=WeltecJobs;Trusted_Connection=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserRegistrectionTbl>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("UserRegistrectionTbl");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Fname)
                .HasMaxLength(20)
                .HasColumnName("FName");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IssSub).HasColumnName("issSub");
            entity.Property(e => e.Mobile).HasMaxLength(20);
            entity.Property(e => e.PasswordHash).HasMaxLength(50);
            entity.Property(e => e.PasswordSalt).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(20);

            entity.HasOne(d => d.Role).WithMany(p => p.UserRegistrectionTbls)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_UserRegistrectionTbl_UserRoleTbl");
        });

        modelBuilder.Entity<UserRoleTbl>(entity =>
        {
            entity.HasKey(e => e.RoleId);

            entity.ToTable("UserRoleTbl");

            entity.Property(e => e.RoleName)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
