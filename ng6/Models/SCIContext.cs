using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ng6.Models
{
    public partial class SCIContext : DbContext
    {
        public SCIContext()
        {
        }

        public SCIContext(DbContextOptions<SCIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<MemberLists> MemberLists { get; set; }
        public virtual DbSet<MemberMemberLists> MemberMemberLists { get; set; }
        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=192.168.0.100;Database=SCI;persist security info=True;user id=sa;password=letmein42;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId });

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_RoleId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.DefaultCollectionId)
                    .HasName("IX_DefaultCollection_Id");

                entity.HasIndex(e => e.UserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.DefaultCollectionId).HasColumnName("DefaultCollection_Id");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.DefaultCollection)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.DefaultCollectionId)
                    .HasConstraintName("FK_dbo.AspNetUsers_dbo.MemberLists_DefaultCollection_Id");
            });

            modelBuilder.Entity<MemberMemberLists>(entity =>
            {
                entity.HasKey(e => new { e.MemberId, e.MemberListId });

                entity.HasIndex(e => e.MemberId)
                    .HasName("IX_Member_Id");

                entity.HasIndex(e => e.MemberListId)
                    .HasName("IX_MemberList_Id");

                entity.Property(e => e.MemberId).HasColumnName("Member_Id");

                entity.Property(e => e.MemberListId).HasColumnName("MemberList_Id");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.MemberMemberLists)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_dbo.MemberMemberLists_dbo.Members_Member_Id");

                entity.HasOne(d => d.MemberList)
                    .WithMany(p => p.MemberMemberLists)
                    .HasForeignKey(d => d.MemberListId)
                    .HasConstraintName("FK_dbo.MemberMemberLists_dbo.MemberLists_MemberList_Id");
            });

            modelBuilder.Entity<Members>(entity =>
            {
                entity.Property(e => e.ChapterPaidThru).HasColumnType("datetime");

                entity.Property(e => e.MemberSince).HasColumnType("datetime");

                entity.Property(e => e.OldKey).HasColumnName("oldKey");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Phone2).HasColumnName("phone2");

                entity.Property(e => e.SciPaidThru).HasColumnType("datetime");

                entity.Property(e => e.Zip).HasColumnName("zip");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey });

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });
        }
    }
}
