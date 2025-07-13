using DogWalkerApp.Application.DTOs;
using DogWalkerApp.Application.Interfaces;
using DogWalkerApp.Infrastructure.Data;
using DogWalkerApp.Infrastructure.Services;
using DogWalkerApp.WinForms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DogWalkerApp.WinForms.Forms
{
    public partial class WalkerForm : Form, IWalkerView
    {
        private readonly DogWalkerDbContext _context;
        private readonly IWalkerService _service;

        public string WalkerName => txtName.Text.Trim();
        public string PhoneNumber => txtPhone.Text.Trim();
        public string FullName => txtName.Text.Trim();

        public bool IsAvailable => chkAvailable.Checked;
        public string SearchTerm => txtSearch.Text.Trim();
        public bool SearchAllChecked => chkSearchAll.Checked;

        public int SelectedWalkerId =>
            dgvWalkers.SelectedRows.Count > 0
                ? Convert.ToInt32(dgvWalkers.SelectedRows[0].Cells["Id"].Value)
                : -1;

        public event EventHandler CreateClicked;
        public event EventHandler UpdateClicked;
        public event EventHandler DeleteClicked;
        public event EventHandler SearchClicked;
        public event EventHandler WalkerSelected;

        private bool _isInitializingWalkers;

        public WalkerForm(DogWalkerDbContext context)
        {
            InitializeComponent();
            _context = context;
            _service = new WalkerService(_context);

            btnCreate.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        public void LoadWalkers(IEnumerable<WalkerDto> walkers)
        {
            _isInitializingWalkers = true;

            dgvWalkers.SelectionChanged -= DgvWalkers_SelectionChanged;

            var displayList = walkers.Select(w => new
            {
                w.Id,
                w.FullName,
                w.PhoneNumber,
                w.IsAvailable
            }).ToList();

            dgvWalkers.DataSource = null;
            dgvWalkers.Columns.Clear();
            dgvWalkers.DataSource = displayList;

            dgvWalkers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvWalkers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWalkers.MultiSelect = false;
            dgvWalkers.ReadOnly = true;

            dgvWalkers.ClearSelection();
            dgvWalkers.CurrentCell = null;

            dgvWalkers.SelectionChanged += DgvWalkers_SelectionChanged;
            _isInitializingWalkers = false;

            ClearForm();
        }


        public void SetWalkerFields(WalkerDto dto)
        {
            txtName.Text = dto.FullName;
            txtPhone.Text = dto.PhoneNumber;
            chkAvailable.Checked = dto.IsAvailable;
        }

        public void ClearForm()
        {
            txtName.Clear();
            txtPhone.Clear();
            chkAvailable.Checked = false;
            dgvWalkers.ClearSelection();
            UpdateButtonStates();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Walkers", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #region Event Handlers

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            if (!ValidateWalkerInput()) return;
            CreateClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (SelectedWalkerId == -1)
            {
                ShowMessage("Please select a walker to update.");
                return;
            }

            if (!ValidateWalkerInput()) return;
            UpdateClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (SelectedWalkerId == -1)
            {
                ShowMessage("Please select a walker to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this walker?", "Confirm", MessageBoxButtons.YesNo);
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

        private void BtnClear_Click(object sender, EventArgs e) => ClearForm();

        private void DgvWalkers_SelectionChanged(object sender, EventArgs e)
        {
            if (_isInitializingWalkers) return;
            WalkerSelected?.Invoke(this, EventArgs.Empty);
            UpdateButtonStates();
        }

        private void TxtName_TextChanged(object sender, EventArgs e) => UpdateButtonStates();
        private void TxtPhone_TextChanged(object sender, EventArgs e) => UpdateButtonStates();
        private void ChkAvailable_CheckedChanged(object sender, EventArgs e) => UpdateButtonStates();

        #endregion

        #region Validation Methods

        private bool ValidateWalkerInput(bool silent = false)
        {
            if (string.IsNullOrWhiteSpace(WalkerName) || !WalkerName.Contains(" "))
            {
                if (!silent) ShowMessage("Please enter full name (first and last).");
                return false;
            }

            if (string.IsNullOrWhiteSpace(PhoneNumber) ||
                !Regex.IsMatch(PhoneNumber, @"^\+?[0-9\s\-\(\)]+$"))
            {
                if (!silent) ShowMessage("Invalid phone number.");
                return false;
            }

            if (PhoneNumber.Length < 8)
            {
                if (!silent) ShowMessage("Phone number is too short.");
                return false;
            }

            return true;
        }

        private void UpdateButtonStates()
        {
            bool hasValidInput = ValidateWalkerInput(silent: true);
            bool walkerSelected = SelectedWalkerId != -1;

            btnCreate.Enabled = hasValidInput && !walkerSelected;
            btnUpdate.Enabled = hasValidInput && walkerSelected;
            btnDelete.Enabled = walkerSelected;
        }

        #endregion
    }
}
