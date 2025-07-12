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

        public int SelectedWalkerId => (int)cmbWalker.SelectedValue;
        public int SelectedClientId => (int)cmbClients.SelectedValue;
        public int SelectedAvailableDogId => (int)cmbAvailableDogs.SelectedValue;
        public List<int> SelectedDogIds { get; private set; } = new();


        public DateTime WalkStartDate => dtpWalkDate.Value;

        public string SearchTerm => txtSearch.Text.Trim();
        public bool SearchAllChecked => chkSearchAll.Checked;

        public event EventHandler CreateClicked;
        public event EventHandler UpdateClicked;
        public event EventHandler DeleteClicked;
        public event EventHandler SearchClicked;
        public event EventHandler WalkSelected;
        public event EventHandler ClientChanged;

        public DogWalkForm()
        {
            InitializeComponent();

            dtpWalkDate.Format = DateTimePickerFormat.Custom;
            dtpWalkDate.CustomFormat = "yyyy-MM-dd HH:mm";
            dtpWalkDate.ShowUpDown = true;

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
            SelectedDogIds = dto.DogIds;

            dgvSelectedDogs.DataSource = dto.DogNames.Select((name, index) => new
            {
                DogId = dto.DogIds[index],
                DogName = name
            }).ToList();

            UpdateButtonStates();
        }

        public void ClearForm()
        {
            txtSearch.Clear();
            chkSearchAll.Checked = false;
            cmbWalker.SelectedIndex = -1;
            cmbClients.SelectedIndex = -1;
            cmbAvailableDogs.DataSource = null;
            dgvSelectedDogs.DataSource = null;
            dtpWalkDate.Value = DateTime.Now;
            SelectedDogIds.Clear();
            dgvWalks.ClearSelection();
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
            if (cmbAvailableDogs.SelectedItem is not DogDto dog || SelectedDogIds.Contains(dog.Id))
                return;

            SelectedDogIds.Add(dog.Id);

            dgvSelectedDogs.DataSource = SelectedDogIds.Select(id => new
            {
                DogId = id,
                DogName = ((List<DogDto>)cmbAvailableDogs.DataSource).First(d => d.Id == id).Name
            }).ToList();

            UpdateButtonStates();
        }

        private void BtnRemoveDog_Click(object? sender, EventArgs e)
        {
            if (dgvSelectedDogs.SelectedRows.Count == 0) return;

            int dogId = Convert.ToInt32(dgvSelectedDogs.SelectedRows[0].Cells["DogId"].Value);
            SelectedDogIds.Remove(dogId);

            dgvSelectedDogs.DataSource = SelectedDogIds.Select(id => new
            {
                DogId = id,
                DogName = ((List<DogDto>)cmbAvailableDogs.DataSource).First(d => d.Id == id).Name
            }).ToList();

            UpdateButtonStates();
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
    }
}
