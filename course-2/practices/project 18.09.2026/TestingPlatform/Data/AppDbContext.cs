using practice.Models;
using Microsoft.EntityFrameworkCore;
using practice.Enums;

namespace practice.Data;

public class AppDbContext : DbContext
{
	public DbSet<User> Users => Set<User>();
	public DbSet<Student> Students => Set<Student>();
	public DbSet<Project> Projects => Set<Project>();
	public DbSet<Group> Groups => Set<Group>();
	public DbSet<Direction> Directions => Set<Direction>();
	public DbSet<Course> Courses => Set<Course>();
	public DbSet<Test> Tests { get; set; }
	public DbSet<Question> Questions { get; set; }
	public DbSet<Answer> Answers { get; set; }
	public DbSet<Attempt> Attempts { get; set; }
	public DbSet<UserAttemptAnswer> UserAttemptAnswers { get; set; }
	public DbSet<UserSelectedOption> UserSelectedOptions { get; set; }
	public DbSet<UserTextAnswer> UserTextAnswers { get; set; }
	public DbSet<TestResult> TestResults { get; set; }

	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<User>(e =>
		{
			e.HasKey(x => x.Id);
			e.HasIndex(x => x.Login).IsUnique();
			e.HasIndex(x => x.Email).IsUnique();
			e.Property(x => x.Login).IsRequired();
			e.Property(x => x.Email).IsRequired();
			e.Property(x => x.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
			e.HasOne(x => x.Student)
				.WithOne(s => s.User)
				.HasForeignKey<Student>(s => s.UserId)
				.OnDelete(DeleteBehavior.Cascade);
		});
		modelBuilder.Entity<Student>(e =>
		{
			e.HasKey(x => x.Id);
			e.Property(x => x.Phone).HasMaxLength(30).IsRequired(); ;
			e.Property(x => x.VkProfileLink).IsRequired();
		});
		modelBuilder.Entity<Direction>(e =>
		{
			e.HasKey(x => x.Id);
			e.Property(x => x.Name).IsRequired();
			e.HasIndex(x => x.Name).IsUnique();
		});
		modelBuilder.Entity<Course>(e =>
		{
			e.HasKey(x => x.Id);
			e.Property(x => x.Name).IsRequired();
			e.HasIndex(x => x.Name).IsUnique();
		});
		modelBuilder.Entity<Project>(e =>
		{
			e.HasKey(x => x.Id);
			e.Property(x => x.Name).IsRequired();
			e.HasIndex(x => x.Name).IsUnique();
		});
		modelBuilder.Entity<Group>(e =>
		{
			e.HasKey(x => x.Id);
			e.Property(x => x.Name).IsRequired();
			e.HasIndex(x => x.Name).IsUnique();

			e.HasOne(x => x.Direction)
				.WithMany(d => d.Groups)
				.HasForeignKey(x => x.DirectionId)
				.OnDelete(DeleteBehavior.Restrict);

			e.HasOne(x => x.Course)
				.WithMany(c => c.Groups)
				.HasForeignKey(x => x.CourseId)
				.OnDelete(DeleteBehavior.Restrict);

			e.HasOne(x => x.Project)
				.WithMany(p => p.Groups)
				.HasForeignKey(x => x.ProjectId)
				.OnDelete(DeleteBehavior.Restrict);
		});
		modelBuilder.Entity<Attempt>(e =>
		{
			e.Property(x => x.StartedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
			e.HasOne(x => x.Test).WithMany().HasForeignKey(x => x.TestId).OnDelete(DeleteBehavior.Restrict);
			e.HasOne(x => x.Student).WithMany(s => s.Attempts).HasForeignKey(x => x.StudentId).OnDelete(DeleteBehavior.Cascade);
		});

		modelBuilder.Entity<UserAttemptAnswer>(e =>
		{
			e.HasIndex(x => new { x.AttemptId, x.QuestionId }).IsUnique();
			e.HasOne(x => x.Attempt).WithMany(a => a.UserAttemptAnswers).HasForeignKey(x => x.AttemptId).OnDelete(DeleteBehavior.Cascade);
			e.HasOne(x => x.Question).WithMany().HasForeignKey(x => x.QuestionId).OnDelete(DeleteBehavior.Restrict);
		});

		modelBuilder.Entity<UserSelectedOption>(e =>
		{
			e.HasOne(x => x.UserAttemptAnswer).WithMany(u => u.UserSelectedOptions).HasForeignKey(x => x.UserAttemptAnswerId).OnDelete(DeleteBehavior.Cascade);
			e.HasOne(x => x.Answer).WithMany().HasForeignKey(x => x.AnswerId).OnDelete(DeleteBehavior.Restrict);
		});

		modelBuilder.Entity<UserTextAnswer>(e =>
		{
			e.HasOne(x => x.UserAttemptAnswer).WithOne(u => u.UserTextAnswer).HasForeignKey<UserTextAnswer>(x => x.UserAttemptAnswerId).OnDelete(DeleteBehavior.Cascade);
		});

		modelBuilder.Entity<TestResult>(e =>
		{
			e.HasIndex(x => new { x.TestId, x.StudentId, x.AttemptId }).IsUnique();
			e.HasOne(x => x.Test).WithMany().HasForeignKey(x => x.TestId).OnDelete(DeleteBehavior.Restrict);
			e.HasOne(x => x.Attempt).WithMany().HasForeignKey(x => x.AttemptId).OnDelete(DeleteBehavior.Cascade);
			e.HasOne(x => x.Student).WithMany(s => s.TestResults).HasForeignKey(x => x.StudentId).OnDelete(DeleteBehavior.Cascade);
		});

	}
}

