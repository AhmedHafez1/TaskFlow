using Microsoft.EntityFrameworkCore;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Infrastructure.Data
{
    public class TaskFlowDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<ProjectMember> ProjectMembers { get; set; }
        public DbSet<TaskComment> TaskComments { get; set; }

        public TaskFlowDbContext(DbContextOptions<TaskFlowDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure User Entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.FirstName).HasMaxLength(100);
                entity.Property(e => e.LastName).HasMaxLength(100);
                entity.Property(e => e.Email).HasMaxLength(100);
            });

            // Cofigure Task Entity
            modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity
                    .HasOne(e => e.Project)
                    .WithMany(e => e.TaskItems)
                    .HasForeignKey(e => e.ProjectId);
                entity.HasOne(t => t.Assignee).WithMany().HasForeignKey(e => e.AssigneeId);
                entity.HasOne(t => t.Author).WithMany().HasForeignKey(e => e.AuthorId);
                entity.Property(e => e.Title).HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(400);
                entity.Property(e => e.TaskPriority);
                entity.Property(e => e.Status);
            });

            // Configure Project Entity
            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Owner).WithMany().HasForeignKey(e => e.OwnerId);
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            // Configure ProjectMember Entity
            modelBuilder.Entity<ProjectMember>(entity =>
            {
                entity.HasKey(e => new { e.ProjectId, e.MemberId });
                entity
                    .HasOne(e => e.Project)
                    .WithMany(p => p.ProjectMembers)
                    .HasForeignKey(e => e.ProjectId);
                entity.HasOne(e => e.Member).WithMany().HasForeignKey(e => e.MemberId);
                entity.HasIndex(e => new { e.ProjectId });
                entity.HasIndex(e => new { e.MemberId });
            });

            // Configure TaskComment Entity
            modelBuilder.Entity<TaskComment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity
                    .HasOne(e => e.TaskItem)
                    .WithMany(t => t.TaskComments)
                    .HasForeignKey(e => e.TaskItemId);
                entity.HasOne(e => e.Author).WithMany().HasForeignKey(e => e.AuthorId);
                entity.Property(e => e.Comment).HasMaxLength(400);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
