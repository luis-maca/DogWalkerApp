using DogWalkerApp.Application.Interfaces;
using DogWalkerApp.Infrastructure.Data;
using DogWalkerApp.Infrastructure.Services;
using DogWalkerApp.WinForms.Forms;
using DogWalkerApp.WinForms.Presenters;
using Microsoft.EntityFrameworkCore;
using System;
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

            InitializeMenu();
        }

        private void InitializeMenu()
        {   
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

            mainMenuStrip.Items.Add(clientsMenuItem);
            mainMenuStrip.Items.Add(subscriptionsMenuItem);
            mainMenuStrip.Items.Add(paymentsMenuItem);
        }

        private void OpenChildForm(Form childForm, string title)
        {
            panelContent.Controls.Clear();

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelContent.Controls.Add(childForm);
            childForm.Show();

            this.Text = $"DogWalkerApp - {title}";
        }
    }

}
