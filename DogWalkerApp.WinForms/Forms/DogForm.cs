using DogWalkerApp.Application.DTOs;
using DogWalkerApp.Domain.Enums;
using DogWalkerApp.Domain.Helpers;
using DogWalkerApp.WinForms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DogWalkerApp.WinForms.Forms
{
    public partial class DogForm : Form, IDogView
    {
        public int SelectedDogId =>
            dgvDogs.SelectedRows.Count > 0
                ? Convert.ToInt32(dgvDogs.SelectedRows[0].Cells["Id"].Value)
                : -1;

        public int SelectedClientId => cmbClients.SelectedItem is ClientDto dto ? dto.Id : -1;
        public string DogName => txtName.Text.Trim();
        public DogBreed SelectedBreed => cmbBreed.SelectedValue is DogBreed breed ? breed : DogBreed.Unknown;

        public int DogAge => (int)numAge.Value;
        public string DogNotes => txtNotes.Text.Trim();

        public string SearchTerm => txtSearch.Text.Trim();
        public bool SearchAllChecked => chkSearchAll.Checked;
        private bool _isInitializingDogs;

        public event EventHandler CreateClicked;
        public event EventHandler UpdateClicked;
        public event EventHandler DeleteClicked;
        public event EventHandler SearchClicked;
        public event EventHandler DogSelected;

        private List<ClientDto> _clients = new();

        public DogForm()
        {
            InitializeComponent();
            LoadBreedDropdown();

            btnCreate.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
       
        private void LoadBreedDropdown()
        {
            var breeds = Enum.GetValues(typeof(DogBreed))
                .Cast<DogBreed>()
                .Select(b => new
                {
                    Value = b,
                    Display = EnumHelper.GetDescription(b)
                })
                .ToList();

            cmbBreed.DataSource = breeds;
            cmbBreed.DisplayMember = "Display";
            cmbBreed.ValueMember = "Value";
        }
        

        public void LoadDogs(IEnumerable<DogDto> dogs)
        {
            _isInitializingDogs = true;

            dgvDogs.SelectionChanged -= DgvDogs_SelectionChanged;

            var displayList = dogs.Select(d => new
            {
                d.Id,
                d.ClientName,
                d.Name,
                Breed = EnumHelper.GetDescription(d.Breed),
                d.Age,
                Notes = d.Notes
            }).ToList();

            dgvDogs.DataSource = null;
            dgvDogs.Columns.Clear();
            dgvDogs.DataSource = displayList;

            dgvDogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDogs.MultiSelect = false;
            dgvDogs.ReadOnly = true;

            dgvDogs.ClearSelection();
            dgvDogs.CurrentCell = null;

            dgvDogs.SelectionChanged += DgvDogs_SelectionChanged;
            _isInitializingDogs = false;

            ClearForm();
        }

        public void LoadClients(IEnumerable<ClientDto> clients)
        {
            _clients = clients.ToList();
            cmbClients.DataSource = _clients;
            cmbClients.DisplayMember = "Name";
            cmbClients.ValueMember = "Id";
        }

        public void SetFields(DogDto dto)
        {
            cmbClients.SelectedValue = dto.ClientId;
            txtName.Text = dto.Name;
            cmbBreed.SelectedItem = dto.Breed;
            numAge.Value = dto.Age;
            txtNotes.Text = dto.Notes;
            UpdateButtonStates();
        }

        public void ClearForm()
        {
            cmbClients.SelectedIndex = -1;
            txtName.Clear();
            cmbBreed.SelectedIndex = -1;
            numAge.Value = 0;
            txtNotes.Clear();
            dgvDogs.ClearSelection();
            UpdateButtonStates();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Dogs", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #region Event Handlers

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (!SearchAllChecked && string.IsNullOrWhiteSpace(SearchTerm))
            {
                ShowMessage("Enter a search term or check 'Search All'.");
                return;
            }

            SearchClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            if (!ValidateDogInput())
                return;

            CreateClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (SelectedDogId == -1)
            {
                ShowMessage("Please select a dog to update.");
                return;
            }

            if (!ValidateDogInput())
                return;

            UpdateClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (SelectedDogId == -1)
            {
                ShowMessage("Please select a dog to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this dog?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
                DeleteClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnClear_Click(object sender, EventArgs e) => ClearForm();

        private void DgvDogs_SelectionChanged(object sender, EventArgs e)
        {
            if (_isInitializingDogs) return;
            DogSelected?.Invoke(this, EventArgs.Empty);
            UpdateButtonStates();
        }

        private void txtName_TextChanged(object sender, EventArgs e) => UpdateButtonStates();
        private void TxtNotes_TextChanged(object sender, EventArgs e) => UpdateButtonStates();
        private void CmbClients_SelectedIndexChanged(object sender, EventArgs e) => UpdateButtonStates();
        private void cmbBreed_SelectedIndexChanged(object sender, EventArgs e) => UpdateButtonStates();
        private void numAge_ValueChanged(object sender, EventArgs e) => UpdateButtonStates();

        #endregion

        #region Validation

        private bool ValidateDogInput(bool silent = false)
        {
            if (cmbClients.SelectedItem is not ClientDto selectedClient)
            {
                if (!silent) ShowMessage("Please select a client.");
                return false;
            }

            if (!selectedClient.HasActiveSubscription)
            {
                if (!silent) ShowMessage("Selected client has no active subscription.");
                return false;
            }

            if (!selectedClient.HasActiveSubscription)
            {
                if (!silent) ShowMessage("Selected client has no active subscription.");
                return false;
            }

            if (selectedClient.DogCount >= selectedClient.MaxDogsAllowed)
            {
                if (!silent) ShowMessage("Client has reached the maximum number of allowed dogs.");
                return false;
            }


            if (string.IsNullOrWhiteSpace(DogName))
            {
                if (!silent) ShowMessage("Please enter the dog's name.");
                return false;
            }

            if (cmbBreed.SelectedItem == null)
            {
                if (!silent) ShowMessage("Please select a dog breed.");
                return false;
            }

            if (DogAge < 0)
            {
                if (!silent) ShowMessage("Dog's age must be 0 or higher.");
                return false;
            }

            return true;
        }

        private void UpdateButtonStates()
        {
            bool hasValidInput = ValidateDogInput(silent: true);
            bool dogSelected = SelectedDogId != -1;

            btnCreate.Enabled = hasValidInput && !dogSelected;
            btnUpdate.Enabled = hasValidInput && dogSelected;
            btnDelete.Enabled = dogSelected;
        }

        #endregion
    }
}
