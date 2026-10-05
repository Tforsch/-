using System;

namespace WinFormsApp1.Models;

public class Habit
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int XpReward { get; set; }
    public DateTime? LastCompletedDate { get; set; }
}
