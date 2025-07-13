using DogWalkerApp.Application.DTOs;
using DogWalkerApp.Application.Interfaces;
using DogWalkerApp.Infrastructure.Data;
using DogWalkerApp.Infrastructure.Services;
using DogWalkerApp.WinForms.Forms;
using DogWalkerApp.WinForms.Presenters;
using DogWalkerApp.WinForms.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DogWalkerApp.WinForms
{
    public partial class ClientForm : Form, IClientView
    {
        private readonly DogWalkerDbContext _context;
        private readonly IClientService _service;

        public string ClientName => txtName.Text.Trim();
        public string PhoneNumber => txtPhone.Text.Trim();
        public string Address => txtAddress.Text.Trim();

        public string SearchTerm => txtSearch.Text.Trim();
        public bool SearchAllChecked => chkSearchAll.Checked;

        public int SelectedClientId =>
                   dgvClients.SelectedRows.Count > 0
        ? Convert.ToInt32(dgvClients.SelectedRows[0].Cells["Id"].Value)
        : -1;


        //Events for button clicks and selection changes
        public event EventHandler CreateClicked;
        public event EventHandler UpdateClicked;
        public event EventHandler DeleteClicked;
        public event EventHandler SearchClicked;
        public event EventHandler ClientSelected;

        private bool _isInitializingClients;

        public ClientForm(DogWalkerDbContext context)
        {
            InitializeComponent();

            //By Default, disable buttons until a client is selected
            btnCreate.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            _context = context;
            _service = new ClientService(_context);
            ClearForm();
        }

        public void LoadClients(IEnumerable<ClientDto> clients)
        {
            _isInitializingClients = true;

            dgvClients.SelectionChanged -= DgvClients_SelectionChanged;

            var display = clients.Select(c => new
            {
                c.Id,
                c.Name,
                c.PhoneNumber,
                c.Address
            }).ToList();

            dgvClients.DataSource = null;
            dgvClients.Columns.Clear();
            dgvClients.DataSource = display;

            dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClients.MultiSelect = false;
            dgvClients.ReadOnly = true;

            dgvClients.ClearSelection();
            dgvClients.CurrentCell = null;

            _isInitializingClients = false;

            dgvClients.SelectionChanged += DgvClients_SelectionChanged;

            ClearForm();
        }

        public void SetClientFields(ClientDto dto)
        {
            if (dto == null) return;

            txtName.Text = dto.Name;
            txtPhone.Text = dto.PhoneNumber;
            txtAddress.Text = dto.Address;
        }

        public void ClearForm()
        {
            dgvClients.SelectionChanged -= DgvClients_SelectionChanged;

            txtName.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtSearch.Clear();
            chkSearchAll.Checked = false;

            dgvClients.ClearSelection();
            dgvClients.CurrentCell = null;

            dgvClients.SelectionChanged += DgvClients_SelectionChanged;

            UpdateButtonStates();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        #region Event Handlers
        private void BtnCreate_Click(object sender, EventArgs e)
        {
            if (!ValidateClientInput())
                return;

            CreateClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (SelectedClientId == -1)
            {
                ShowMessage("Please select a client to update.");
                return;
            }

            if (!ValidateClientInput())
                return;

            UpdateClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (SelectedClientId == -1)
            {
                ShowMessage("Please select a client to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this client?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
                DeleteClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (!SearchAllChecked && string.IsNullOrWhiteSpace(SearchTerm))
            {
                ShowMessage("Enter a search term or check 'Search All'.");
                return;
            }

            SearchClicked?.Invoke(this, EventArgs.Empty);
        }

        private void DgvClients_SelectionChanged(object sender, EventArgs e)
        {
            if (_isInitializingClients) return;

            ClientSelected?.Invoke(this, EventArgs.Empty);
            UpdateButtonStates();
        }


        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        
        private void TxtName_TextChanged(object sender, EventArgs e) => UpdateButtonStates();
        private void TxtPhone_TextChanged(object sender, EventArgs e) => UpdateButtonStates();
        private void TxtAddress_TextChanged(object sender, EventArgs e) => UpdateButtonStates();

        #endregion

        #region Validation Methods
        private bool ValidateClientInput(bool silent = false)
        {
            if (string.IsNullOrWhiteSpace(ClientName) || !ClientName.Contains(" "))
            {
                if (!silent) ShowMessage("Please enter full name (first and last).");
                return false;
            }

            if (string.IsNullOrWhiteSpace(PhoneNumber) ||
                !System.Text.RegularExpressions.Regex.IsMatch(PhoneNumber, @"^\+?[0-9\s\-\(\)]+$"))
            {
                if (!silent) ShowMessage("Invalid phone number.");
                return false;
            }

            if (PhoneNumber.Length < 8)
            {
                if (!silent) ShowMessage("Phone number is too short.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Address))
            {
                if (!silent) ShowMessage("Address is required.");
                return false;
            }

            return true;
        }
        
        #endregion

        private void UpdateButtonStates()
        {
            bool hasValidInput = ValidateClientInput(silent: true);
            bool clientSelected = SelectedClientId != -1;

            btnCreate.Enabled = hasValidInput && !clientSelected;
            btnUpdate.Enabled = hasValidInput && clientSelected;
            btnDelete.Enabled = clientSelected;
        }


    }
}
