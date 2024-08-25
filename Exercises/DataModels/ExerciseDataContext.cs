using Common.Configuration;
using Microsoft.EntityFrameworkCore;

namespace DataModels;
public class ExerciseDataContext : DbContext
{
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<ExerciseSet> ExerciseSets { get; set; }

    public ExerciseDataContext(DbContextOptions<ExerciseDataContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Settings settings = new();
        if (settings.InMigrationEnvironment)
        {
            string connectionString = "userid=root;password=password;server=localhost;port=3307;database=fortitrack_exercises";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Exercise>()
            .HasMany(e => e.ExerciseSets)
            .WithOne(e => e.Exercise)
            .HasForeignKey(e => e.ExerciseId)
            .IsRequired();
    }
}