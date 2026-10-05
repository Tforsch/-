using System;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp1.Data;
using WinFormsApp1.Models;
using WinFormsApp1.Services;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly AppDbContext _dbContext;
        private readonly GameEngine _gameEngine;

        public Form1()
        {
            InitializeComponent();

            _dbContext = new AppDbContext();
            _gameEngine = new GameEngine(_dbContext);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Process any HP penalties from previous missed days on startup
            _gameEngine.ProcessDailyReset();

            LoadHabits();
            RefreshUI();

            // Subscribe to item check events
            clbHabits.ItemCheck += ClbHabits_ItemCheck;
        }

        private void LoadHabits()
        {
            clbHabits.Items.Clear();
            var habits = _dbContext.Habits.ToList();

            foreach (var habit in habits)
            {
                bool isCompletedToday = habit.LastCompletedDate?.Date == DateTime.Today;
                clbHabits.Items.Add(habit, isCompletedToday);
            }
            
            clbHabits.DisplayMember = "Name";
        }

        private void ClbHabits_ItemCheck(object? sender, ItemCheckEventArgs e)
        {
            var habit = (Habit)clbHabits.Items[e.Index];

            // Handle checking the habit
            if (e.NewValue == CheckState.Checked)
            {
                _gameEngine.CompleteHabit(habit);

                // Run UI update asynchronously to avoid UI freezing or WinForms state issues mid-event
                this.BeginInvoke(new Action(RefreshUI));
            }
            // Handle unchecking (e.g. attempting to cheat or accidental uncheck)
            else if (e.NewValue == CheckState.Unchecked)
            {
                if (habit.LastCompletedDate?.Date == DateTime.Today)
                {
                    // Prevent unchecking for today
                    e.NewValue = CheckState.Checked;
                    MessageBox.Show("Habit already completed for today!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void RefreshUI()
        {
            var player = _gameEngine.GetPlayer();

            // Safely update labels
            lblLevel.Text = $"Level: {player.Level}";
            lblHp.Text = $"HP: {player.CurrentHp} / 100";
            lblXp.Text = $"XP: {player.CurrentXp} / 100";

            // Update Progress Bars safely (clamped to 0-100 to avoid exceptions)
            pbHp.Maximum = 100;
            pbHp.Value = Math.Max(0, Math.Min(player.CurrentHp, 100));

            pbXp.Maximum = 100;
            pbXp.Value = Math.Max(0, Math.Min(player.CurrentXp, 100));
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Safely dispose the DbContext
            _dbContext?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
