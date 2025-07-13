
using DogWalkerApp.Application.Interfaces;
using DogWalkerApp.Infrastructure.Data;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DogWalkerApp.WinForms
{
    public partial class HomeForm : Form
    {
        private readonly DogWalkerDbContext _context;
        private readonly IDogWalkService _dogWalkService;

        public HomeForm(DogWalkerDbContext context, IDogWalkService dogWalkService)
        {
            InitializeComponent();
            _context = context;
            _dogWalkService = dogWalkService;
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            LoadWeeklySummary();
            LoadTodayWalks();
        }

        private void LoadWeeklySummary()
        {
            var today = DateTime.Today;
            var weekStart = today.AddDays(-(int)today.DayOfWeek);
            var weekEnd = weekStart.AddDays(7);

            var walks = _dogWalkService.GetByDateRange(weekStart, weekEnd);
            lblWeeklySummary.Text = $"🐾 Walks scheduled this week: {walks.Count()}";
        }

        private void LoadTodayWalks()
        {
            var today = DateTime.Today;
            var walks = _dogWalkService.GetByDateRange(today, today);

            var walkData = walks
                .SelectMany(walk => walk.DogNames.Select((dog, index) => new
                {
                    Dog = dog,
                    Owner = walk.ClientNames.ElementAtOrDefault(index) ?? "Unknown",
                    Walker = walk.WalkerName,
                    Time = walk.WalkDate.ToShortTimeString()
                }))
                .ToList();

            dgvTodayDogs.DataSource = walkData;
        }
    }
}
