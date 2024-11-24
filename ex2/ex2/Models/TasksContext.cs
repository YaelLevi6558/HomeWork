using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ex2.Models;

public partial class TasksContext : DbContext
{
    public TasksContext()
    {
    }

    public TasksContext(DbContextOptions<TasksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attachment> Attachments { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Tasks> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attachment>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Path)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Projects");

            entity.ToTable("Project");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Subject)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<Tasks>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsFixedLength();

            entity.HasOne(d => d.Project).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_Tasks_Projects");

            entity.HasOne(d => d.User).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Tasks_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Users");

            entity.ToTable("User");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Adress)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
