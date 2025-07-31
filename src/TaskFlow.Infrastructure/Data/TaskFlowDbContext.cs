using Microsoft.EntityFrameworkCore;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Infrastructure.Data
{
    public class TaskFlowDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }

        public TaskFlowDbContext(DbContextOptions<TaskFlowDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure User Entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Email).IsRequired();
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
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Description).IsRequired();
                entity.Property(e => e.TaskPriority).IsRequired();
                entity.Property(e => e.Status).IsRequired();
            });

            // Configure Project Entity
            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Owner).WithMany().HasForeignKey(e => e.OwnerId);
                entity.Property(e => e.Name).IsRequired();
            });

            // Configure ProjectMember Entity
            modelBuilder.Entity<ProjectMember>(entity =>
            {
                entity.HasKey(e => new { e.ProjectId, e.MemberId });
            });
        }
    }
}
