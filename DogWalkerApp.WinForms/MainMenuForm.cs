using DogWalkerApp.Application.Interfaces;
using DogWalkerApp.Infrastructure.Data;
using DogWalkerApp.Infrastructure.Data;
using DogWalkerApp.Infrastructure.Services;
using DogWalkerApp.WinForms.Presenters;
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
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            var form = new ClientForm();
            var service = new ClientService(_context);
            var presenter = new ClientPresenter(form, service);
            form.ShowDialog();
        }

    }
}
