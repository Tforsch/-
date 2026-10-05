using System;
using System.Linq;
using WinFormsApp1.Data;
using WinFormsApp1.Models;

namespace WinFormsApp1.Services;

public class GameEngine
{
    private readonly AppDbContext _dbContext;

    public GameEngine(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public void CompleteHabit(Habit habit)
    {
        if (habit == null) throw new ArgumentNullException(nameof(habit));

        // Prevent completing the same habit multiple times in a single day
        if (habit.LastCompletedDate?.Date == DateTime.Today)
            return;

        var player = GetPlayer();

        player.CurrentXp += habit.XpReward;

        // Level up logic: Level up every 100 XP, keep remainder
        while (player.CurrentXp >= 100)
        {
            player.CurrentXp -= 100;
            player.Level++;
            player.CurrentHp = 100; // Reward: fully restore HP on level up
        }

        habit.LastCompletedDate = DateTime.Today;

        _dbContext.Habits.Update(habit);
        _dbContext.Players.Update(player);
        _dbContext.SaveChanges();
    }

    public void ProcessDailyReset()
    {
        var player = GetPlayer();
        var habits = _dbContext.Habits.ToList();
        var yesterday = DateTime.Today.AddDays(-1);

        int missedHabits = 0;

        foreach (var habit in habits)
        {
            // If the habit was never completed, or not completed yesterday (or today)
            if (habit.LastCompletedDate == null || habit.LastCompletedDate.Value.Date < yesterday)
            {
                missedHabits++;
            }
        }

        if (missedHabits > 0)
        {
            // Penalty: 10 HP deducted per missed habit
            player.CurrentHp -= missedHabits * 10;

            // Game Over / Severe Penalty if HP drops to 0 or below
            if (player.CurrentHp <= 0)
            {
                player.CurrentHp = 100;
                player.CurrentXp = 0;
                player.Level = Math.Max(1, player.Level - 1); // Lose a level
            }

            _dbContext.Players.Update(player);
            _dbContext.SaveChanges();
        }
    }

    public Player GetPlayer()
    {
        // Get the first player, or create one if it doesn't exist
        var player = _dbContext.Players.FirstOrDefault();
        if (player == null)
        {
            player = new Player { CurrentHp = 100, CurrentXp = 0, Level = 1 };
            _dbContext.Players.Add(player);
            _dbContext.SaveChanges();
        }
        return player;
    }
}
