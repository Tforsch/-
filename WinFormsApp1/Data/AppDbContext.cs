using Microsoft.EntityFrameworkCore;
using WinFormsApp1.Models;

namespace WinFormsApp1.Data;

public class AppDbContext : DbContext
{
    public DbSet<Player> Players { get; set; } = null!;
    public DbSet<Habit> Habits { get; set; } = null!;

    public AppDbContext()
    {
        // Ensure the SQLite database and schema are created locally
        bool created = Database.EnsureCreated();
        
        // Seed default habits only on first DB creation
        if (created)
        {
            Habits.AddRange(
                new Habit { Name = "Drink Water", XpReward = 10 },
                new Habit { Name = "Read 10 Pages", XpReward = 20 },
                new Habit { Name = "Exercise", XpReward = 30 }
            );
            SaveChanges();
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configures EF Core to use a local SQLite file in the application output directory
        optionsBuilder.UseSqlite("Data Source=habittracker.db");
    }
}
