using DogWalkerApp.Application.Interfaces;
using DogWalkerApp.Infrastructure.Data;
using DogWalkerApp.Infrastructure.Services;
using DogWalkerApp.WinForms.Forms;
using DogWalkerApp.WinForms.Presenters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace DogWalkerApp.WinForms
{
    public partial class MainMenuForm : Form
    {
        private readonly DogWalkerDbContext _context;

        public MainMenuForm(DogWalkerDbContext context)
        {
            _context = context;

            InitializeComponent();            
            InitializeMenu();
            var form = new HomeForm(_context, new DogWalkService(_context));
            OpenChildForm(form, "Home");

        }

        private void InitializeMenu()
        {
            //Home
            var homeMenuItem = new ToolStripMenuItem("Home");
            homeMenuItem.Click += (s, e) =>
            {
                var form = new HomeForm(_context, new DogWalkService(_context));
                OpenChildForm(form, "Home");
            };

            //Clients
            var clientsMenuItem = new ToolStripMenuItem("Clients");
            clientsMenuItem.Click += (s, e) =>
            {
                var form = new ClientForm(_context);
                new ClientPresenter(form, new ClientService(_context));
                OpenChildForm(form, "Clients");
            };

            //Subscriptions
            var subscriptionsMenuItem = new ToolStripMenuItem("Subscriptions");
            subscriptionsMenuItem.Click += (s, e) =>
            {
                var form = new SubscriptionForm();
                new SubscriptionPresenter(form, new SubscriptionService(_context), new ClientService(_context));
                OpenChildForm(form, "Subscriptions");
            };

            //Payments
            var paymentsMenuItem = new ToolStripMenuItem("Payments");
            paymentsMenuItem.Click += (s, e) =>
            {
                var form = new PaymentForm();
                new PaymentPresenter(
                    form,
                    new PaymentService(_context),
                    new SubscriptionService(_context)
                );
                OpenChildForm(form, "Payments");
            };

            //Walkers
            var walkersMenuItem = new ToolStripMenuItem("Walkers");
            walkersMenuItem.Click += (s, e) =>
            {
                var form = new WalkerForm(_context);
                new WalkerPresenter(form, new WalkerService(_context));
                OpenChildForm(form, "Walkers");
            };

            //Dogs
            var dogsMenuItem = new ToolStripMenuItem("Dogs");
            dogsMenuItem.Click += (s, e) =>
            {
                var form = new DogForm();
                new DogPresenter(form, new DogService(_context), new ClientService(_context));
                OpenChildForm(form, "Dogs");
            };

            //DogWalks
            var dogWalksMenuItem = new ToolStripMenuItem("Dog Walks");
            dogWalksMenuItem.Click += (s, e) =>
            {
                var form = new DogWalkForm();
                new DogWalkPresenter(form, new DogWalkService(_context), new DogService(_context),new WalkerService(_context), new ClientService(_context));
                OpenChildForm(form, "Dog Walks");
            };

            var exitMenuItem = new ToolStripMenuItem("Exit");
            exitMenuItem.Alignment = ToolStripItemAlignment.Right;
            exitMenuItem.ForeColor = Color.Red;
            exitMenuItem.Font = new Font(exitMenuItem.Font, FontStyle.Bold);
            exitMenuItem.Click += (s, e) =>
            {
                var result = MessageBox.Show(
                    "Are you sure you want to log out and return to the login screen?",
                    "Confirm Exit",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    this.Hide();
                    var loginForm = new LoginForm(new LoginService(_context), _context);
                    loginForm.Show();
                }
            };


            mainMenuStrip.Items.Add(homeMenuItem);
            mainMenuStrip.Items.Add(clientsMenuItem);
            mainMenuStrip.Items.Add(subscriptionsMenuItem);
            mainMenuStrip.Items.Add(paymentsMenuItem);
            mainMenuStrip.Items.Add(walkersMenuItem);
            mainMenuStrip.Items.Add(dogsMenuItem);
            mainMenuStrip.Items.Add(dogWalksMenuItem);
            mainMenuStrip.Items.Add(exitMenuItem);

        }

        private Form _activeForm;

        private void OpenChildForm(Form childForm, string title)
        {
            if (_activeForm != null)
                _activeForm.Close();

            _activeForm = childForm;
            _activeForm.TopLevel = false;
            _activeForm.FormBorderStyle = FormBorderStyle.None;
            _activeForm.Dock = DockStyle.Fill;

            this.Controls.Add(_activeForm);
            this.Tag = _activeForm;
            _activeForm.BringToFront();
            _activeForm.Show();
            this.Text = $"Dog Walker App - {title}";
        }


        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            var form = new HomeForm(_context, new DogWalkService(_context));
            OpenChildForm(form, "Home");
        }

    }

}
