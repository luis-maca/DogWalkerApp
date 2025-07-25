﻿using DogWalkerApp.Application.DTOs;
using DogWalkerApp.Domain.Enums;
using DogWalkerApp.Domain.Helpers;
using DogWalkerApp.WinForms.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogWalkerApp.WinForms.Forms
{
    public partial class SubscriptionForm : Form, ISubscriptionView
    {
        public int SelectedSubscriptionId =>
            dgvSubscriptions.SelectedRows.Count > 0
                ? Convert.ToInt32(dgvSubscriptions.SelectedRows[0].Cells["Id"].Value)
                : -1;

        public int SelectedClientId => (int)cmbClients.SelectedValue;
        public SubscriptionFrequency SelectedFrequency => (SubscriptionFrequency)cmbFrequency.SelectedValue;
        public int MaxDogsAllowed => (int)numMaxDogs.Value;
        public bool IsActive => chkIsActive.Checked;

        public string SearchTerm => txtSearch.Text.Trim();
        public bool SearchAllChecked => chkSearchAll.Checked;
        private bool _isInitializingSubscriptions;


        public event EventHandler CreateClicked;
        public event EventHandler UpdateClicked;
        public event EventHandler DeleteClicked;
        public event EventHandler SearchClicked;
        public event EventHandler SubscriptionSelected;

        public SubscriptionForm()
        {
            InitializeComponent();
            LoadFrequencyDropdown();
        }

      
        public void LoadSubscriptions(IEnumerable<SubscriptionDto> items)
        {
            _isInitializingSubscriptions = true;

            dgvSubscriptions.SelectionChanged -= DgvSubscriptions_SelectionChanged;

            var display = items.Select(s => new
            {
                s.Id,
                s.ClientName,
                Frequency = s.Frequency.ToString(),
                s.MaxDogsAllowed,
                s.IsActive
            }).ToList();

            dgvSubscriptions.DataSource = null;
            dgvSubscriptions.Columns.Clear();
            dgvSubscriptions.DataSource = display;

            dgvSubscriptions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSubscriptions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSubscriptions.MultiSelect = false;
            dgvSubscriptions.ReadOnly = true;

            dgvSubscriptions.ClearSelection();
            dgvSubscriptions.CurrentCell = null;

            dgvSubscriptions.SelectionChanged += DgvSubscriptions_SelectionChanged;
            _isInitializingSubscriptions = false;

            ClearForm();
        }


        public void LoadClients(IEnumerable<ClientDto> clients)
        {
            cmbClients.DataSource = clients.ToList();
            cmbClients.DisplayMember = "Name";
            cmbClients.ValueMember = "Id";
        }

        private void LoadFrequencyDropdown()
        {
            var frequencies = Enum.GetValues(typeof(SubscriptionFrequency))
                .Cast<SubscriptionFrequency>()
                .Select(f => new
                {
                    Value = f,
                    Display = EnumHelper.GetDescription(f)
                })
                .ToList();

            cmbFrequency.DataSource = frequencies;
            cmbFrequency.DisplayMember = "Display";
            cmbFrequency.ValueMember = "Value";
        }


        public void SetFields(SubscriptionDto dto)
        {
            cmbClients.SelectedValue = dto.ClientId;
            cmbFrequency.SelectedValue = dto.Frequency;
            numMaxDogs.Value = dto.MaxDogsAllowed;
            chkIsActive.Checked = dto.IsActive;
            UpdateButtonStates();
        }


        public void ClearForm()
        {
            txtSearch.Clear();
            chkSearchAll.Checked = false;
            cmbClients.SelectedIndex = -1;
            cmbFrequency.SelectedIndex = -1;
            numMaxDogs.Value = 0;
            chkIsActive.Checked = false;
            dgvSubscriptions.ClearSelection();
            UpdateButtonStates();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Subscription", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #region Event Handlers
        private void BtnSearch_Click(object sender, EventArgs e) => SearchClicked?.Invoke(this, EventArgs.Empty);
        private void BtnCreate_Click(object sender, EventArgs e)
        {
            if (!ValidateSubscriptionInput(isCreate:true))
                return;

            CreateClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnUpdate_Click(object sender, EventArgs e) 
        {
            if (!ValidateSubscriptionInput(isCreate:false))
                return;

            UpdateClicked?.Invoke(this, EventArgs.Empty);
                
        }
        private void BtnDelete_Click(object sender, EventArgs e) => DeleteClicked?.Invoke(this, EventArgs.Empty);
        private void BtnClear_Click(object sender, EventArgs e) => ClearForm();

        private void CmbClients_SelectedIndexChanged(object sender, EventArgs e) => UpdateButtonStates();
        private void CmbFrequency_SelectedIndexChanged(object sender, EventArgs e) => UpdateButtonStates();
        private void NumMaxDogs_ValueChanged(object sender, EventArgs e) => UpdateButtonStates();
        private void ChkIsActive_CheckedChanged(object sender, EventArgs e) => UpdateButtonStates();

        private void DgvSubscriptions_SelectionChanged(object sender, EventArgs e)
        {
            if(_isInitializingSubscriptions) return;

            SubscriptionSelected?.Invoke(this, EventArgs.Empty);
            UpdateButtonStates();
        }

        #endregion

        private bool ValidateSubscriptionInput(bool silent = false, bool isCreate = false)
        {
            if (cmbClients.SelectedItem == null)
            {
                if (!silent) ShowMessage("Please select a client.");
                return false;
            }

            if (cmbFrequency.SelectedItem == null)
            {
                if (!silent) ShowMessage("Please select a subscription frequency.");
                return false;
            }

            if (numMaxDogs.Value < 1)
            {
                if (!silent) ShowMessage("Max number of dogs must be at least 1.");
                return false;
            }

            if (isCreate && !IsActive)
            {
                if (!silent) ShowMessage("New subscriptions must be active.");
                return false;
            }

            return true;
        }


        private void UpdateButtonStates()
        {
            bool hasValidInput = ValidateSubscriptionInput(silent: true);
            bool subscriptionSelected = SelectedSubscriptionId != -1;

            btnCreate.Enabled = hasValidInput && !subscriptionSelected;
            btnUpdate.Enabled = hasValidInput && subscriptionSelected;
            btnDelete.Enabled = subscriptionSelected;
        }


    }
}
