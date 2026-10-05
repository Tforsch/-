namespace WinFormsApp1.Models;

public class Player
{
    public int Id { get; set; }
    public int CurrentHp { get; set; } = 100;
    public int CurrentXp { get; set; } = 0;
    public int Level { get; set; } = 1;
}
