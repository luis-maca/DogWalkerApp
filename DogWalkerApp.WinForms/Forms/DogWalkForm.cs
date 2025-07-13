using DogWalkerApp.Application.DTOs;
using DogWalkerApp.WinForms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace DogWalkerApp.WinForms.Forms
{
    public partial class DogWalkForm : Form, IDogWalkView
    {
        public int SelectedWalkId =>
            dgvWalks.SelectedRows.Count > 0
                ? Convert.ToInt32(dgvWalks.SelectedRows[0].Cells["Id"].Value)
                : -1;

        public int SelectedClientId =>
            cmbClients.SelectedItem is ClientDto c ? c.Id : -1;

        public int SelectedWalkerId =>
            cmbWalker.SelectedItem is WalkerDto w ? w.Id : -1;

        public int SelectedAvailableDogId =>
            cmbAvailableDogs.SelectedItem is DogDto d ? d.Id : -1;
        public List<int> SelectedDogIds => _selectedDogs.Select(d => d.Id).ToList();


        public DateTime WalkDate => dtpWalkDate.Value.Date + dtpWalkTime.Value.TimeOfDay;
        public int DurationMinutes => (int)numDuration.Value;

        public string SearchTerm => txtSearch.Text.Trim();
        public bool SearchAllChecked => chkSearchAll.Checked;

        public event EventHandler CreateClicked;
        public event EventHandler UpdateClicked;
        public event EventHandler DeleteClicked;
        public event EventHandler SearchClicked;
        public event EventHandler WalkSelected;
        public event EventHandler ClientChanged;

        private readonly List<DogDto> _selectedDogs = new();


        public DogWalkForm()
        {
            InitializeComponent();

            dtpWalkDate.ShowUpDown = false;

            dgvWalks.SelectionChanged += DgvWalks_SelectionChanged;
            cmbClients.SelectedIndexChanged += cmbClients_SelectedIndexChanged;

            btnCreate.Click += BtnCreate_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnSearch.Click += BtnSearch_Click;
            btnClear.Click += BtnClear_Click;

            btnAddDogToWalk.Click += btnAddDogToWalk_Click;
            btnRemoveDogFromWalk.Click += BtnRemoveDog_Click;

            cmbWalker.SelectedIndexChanged += (_, _) => UpdateButtonStates();
            cmbAvailableDogs.SelectedIndexChanged += (_, _) => UpdateButtonStates();
        }

        public void LoadDogWalks(IEnumerable<DogWalkDto> walks)
        {
            var display = walks.Select(w => new
            {
                w.Id,
                w.WalkDate,
                w.DurationMinutes,
                Walker = w.WalkerName,
                Dogs = string.Join(", ", w.DogNames),
                Clients = string.Join(", ", w.ClientNames)
            }).ToList();

            dgvWalks.DataSource = display;
        }

        public void LoadWalkers(IEnumerable<WalkerDto> walkers)
        {
            cmbWalker.DataSource = walkers.ToList();
            cmbWalker.DisplayMember = "FullName";
            cmbWalker.ValueMember = "Id";
        }

        public void LoadClients(IEnumerable<ClientDto> clients)
        {
            cmbClients.DataSource = clients.ToList();
            cmbClients.DisplayMember = "Name";
            cmbClients.ValueMember = "Id";
        }

        public void LoadAvailableDogs(IEnumerable<DogDto> dogs)
        {
            var list = dogs.ToList();
            cmbAvailableDogs.DataSource = list;
            cmbAvailableDogs.DisplayMember = "Name";
            cmbAvailableDogs.ValueMember = "Id";
        }


        public void SetFields(DogWalkDto dto)
        {
            cmbWalker.SelectedValue = dto.WalkerId;
            dtpWalkDate.Value = dto.WalkDate;

            _selectedDogs.Clear();

            for (int i = 0; i < dto.DogIds.Count; i++)
            {
                _selectedDogs.Add(new DogDto
                {
                    Id = dto.DogIds[i],
                    Name = dto.DogNames[i]
                });
            }

            RefreshSelectedDogsGrid();
            UpdateButtonStates();
        }


        public void ClearForm()
        {
            txtSearch.Clear();
            chkSearchAll.Checked = false;
            /*cmbWalker.SelectedIndex = -1;
            cmbClients.SelectedIndex = -1;*/
            cmbAvailableDogs.DataSource = null;
            dgvSelectedDogs.DataSource = null;
            dtpWalkDate.Value = DateTime.Now;
            SelectedDogIds.Clear();
            dgvWalks.ClearSelection();
            _selectedDogs.Clear();
            dgvSelectedDogs.DataSource = null;
            UpdateButtonStates();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Dog Walks", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            CreateClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            UpdateClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnDelete_Click(object sender, EventArgs e) =>
            DeleteClicked?.Invoke(this, EventArgs.Empty);

        private void BtnSearch_Click(object sender, EventArgs e) =>
            SearchClicked?.Invoke(this, EventArgs.Empty);

        private void BtnClear_Click(object sender, EventArgs e) => ClearForm();

        private void DgvWalks_SelectionChanged(object sender, EventArgs e)
        {
            WalkSelected?.Invoke(this, EventArgs.Empty);
            UpdateButtonStates();
        }

        private void cmbClients_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ClientChanged?.Invoke(this, EventArgs.Empty);
            UpdateButtonStates();
        }

        private void btnAddDogToWalk_Click(object? sender, EventArgs e)
        {
            if (cmbAvailableDogs.SelectedItem is not DogDto dog)
                return;

            if (_selectedDogs.Any(d => d.Id == dog.Id))
                return;

            _selectedDogs.Add(dog);

            RefreshSelectedDogsGrid();
            UpdateButtonStates();
        }


        private void BtnRemoveDog_Click(object? sender, EventArgs e)
        {
            if (dgvSelectedDogs.SelectedRows.Count == 0) return;

            // Get the DogId from the selected row
            if (int.TryParse(dgvSelectedDogs.SelectedRows[0].Cells["DogId"].Value?.ToString(), out int dogId))
            {
                var dogToRemove = _selectedDogs.FirstOrDefault(d => d.Id == dogId);
                if (dogToRemove != null)
                {
                    _selectedDogs.Remove(dogToRemove);
                    RefreshSelectedDogsGrid();
                    UpdateButtonStates();
                }
            }
        }

        private bool ValidateInput(bool silent = false)
        {
            if (cmbWalker.SelectedItem == null)
            {
                if (!silent) ShowMessage("Please select a walker.");
                return false;
            }

            if (SelectedDogIds.Count == 0)
            {
                if (!silent) ShowMessage("Please add at least one dog.");
                return false;
            }

            return true;
        }

        private void UpdateButtonStates()
        {
            bool hasValidInput = ValidateInput(silent: true);
            bool selected = SelectedWalkId != -1;

            btnCreate.Enabled = hasValidInput && !selected;
            btnUpdate.Enabled = hasValidInput && selected;
            btnDelete.Enabled = selected;
        }

        private void RefreshSelectedDogsGrid()
        {
            dgvSelectedDogs.DataSource = _selectedDogs
                .Select(d => new
                {
                    DogId = d.Id,
                    DogName = d.Name
                })
                .ToList();
        }

    }
}
