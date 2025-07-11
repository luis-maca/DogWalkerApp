using DogWalkerApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogWalkerApp.WinForms
{
    public partial class MainMenuForm : Form
    {
        private readonly DogWalkerDbContext _context;
        public MainMenuForm(DogWalkerDbContext context)
        {
            InitializeComponent();
            _context = context;

            var walkerCount = _context.Walkers.Count();
            MessageBox.Show($"Seeded Walkers: {walkerCount}");
        }
    }
}
