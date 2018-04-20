using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HappyCooksApi.Models
{
    public partial class HappyCooksContext : DbContext
    {
        public virtual DbSet<Contributor> Contributor { get; set; }
        public virtual DbSet<DifficultyLevels> DifficultyLevels { get; set; }
        public virtual DbSet<ProjectContributors> ProjectContributors { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }

        public HappyCooksContext(DbContextOptions<HappyCooksContext> options): base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contributor>(entity =>
            {
                entity.ToTable("contributor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bio).HasColumnName("bio");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ScreenName)
                    .IsRequired()
                    .HasColumnName("screen_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DifficultyLevels>(entity =>
            {
                entity.ToTable("difficulty_levels");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasColumnName("display_name")
                    .HasMaxLength(50);

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<ProjectContributors>(entity =>
            {
                entity.ToTable("project_contributors");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ContributorId).HasColumnName("contributor_id");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.HasOne(d => d.Contributor)
                    .WithMany(p => p.ProjectContributors)
                    .HasForeignKey(d => d.ContributorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pattern_Contributor_Contributor_id");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectContributors)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pattern_Contributor_pattern_id");
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.ToTable("projects");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.DifficultyId).HasColumnName("difficulty_id");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasColumnName("display_name")
                    .HasMaxLength(150);

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.MakeTime)
                    .HasColumnName("make_time")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Pattern).HasColumnName("pattern");

                entity.Property(e => e.Steps).HasColumnName("steps");

                entity.Property(e => e.TagLine)
                    .HasColumnName("tag_line")
                    .HasMaxLength(250);

                entity.HasOne(d => d.Difficulty)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.DifficultyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pattern_Difficulty");
            });
        }
    }
}
