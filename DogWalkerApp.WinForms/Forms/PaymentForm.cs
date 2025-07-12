using DogWalkerApp.Application.DTOs;
using DogWalkerApp.Domain.Enums;
using DogWalkerApp.Domain.Helpers;
using DogWalkerApp.WinForms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DogWalkerApp.WinForms.Forms
{
    public partial class PaymentForm : Form, IPaymentView
    {
        public int SelectedPaymentId =>
            dgvPayments.SelectedRows.Count > 0
                ? Convert.ToInt32(dgvPayments.SelectedRows[0].Cells["Id"].Value)
                : -1;

        public int SelectedSubscriptionId => (int)cmbSubscriptions.SelectedValue;
        public DateTime PaymentDate => dtpDate.Value;
        public decimal Amount => numAmount.Value;
        public PaymentMethod SelectedMethod => (PaymentMethod)cmbMethod.SelectedValue;

        public string SearchTerm => txtSearch.Text.Trim();
        public bool SearchAllChecked => chkSearchAll.Checked;

        public event EventHandler CreateClicked;
        public event EventHandler UpdateClicked;
        public event EventHandler DeleteClicked;
        public event EventHandler SearchClicked;
        public event EventHandler PaymentSelected;

        public PaymentForm()
        {
            InitializeComponent();
            InitializeGrid();
            LoadPaymentMethodDropdown();


            dtpDate.MinDate = new DateTime(DateTime.Now.Year - 1, 1, 1);
            dtpDate.MaxDate = new DateTime(DateTime.Now.Year, 12, 31);
            dtpDate.Value = DateTime.Today;

            cmbSubscriptions.SelectedIndexChanged += (s, e) => UpdateButtonStates();
            cmbMethod.SelectedIndexChanged += (s, e) => UpdateButtonStates();
            numAmount.ValueChanged += (s, e) => UpdateButtonStates();
            dtpDate.ValueChanged += (s, e) => UpdateButtonStates();

            dgvPayments.SelectionChanged += DgvPayments_SelectionChanged;

            btnCreate.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }


        private void InitializeGrid()
        {
            dgvPayments.Columns.Clear();

            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Visible = false
            });

            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Client",
                HeaderText = "Client",
                DataPropertyName = "Client"
            });

            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Date",
                HeaderText = "Date",
                DataPropertyName = "Date",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" }
            });

            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Amount",
                HeaderText = "Amount",
                DataPropertyName = "Amount"
            });

            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Method",
                HeaderText = "Method",
                DataPropertyName = "Method"
            });


            dgvPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPayments.MultiSelect = false;
            dgvPayments.ReadOnly = true;

            dgvPayments.SelectionChanged += DgvPayments_SelectionChanged;
        }

        private void LoadPaymentMethodDropdown()
        {
            var methods = Enum.GetValues(typeof(PaymentMethod))
                .Cast<PaymentMethod>()
                .Select(m => new
                {
                    Value = m,
                    Display = EnumHelper.GetDescription(m)
                })
                .ToList();

            cmbMethod.DataSource = methods;
            cmbMethod.DisplayMember = "Display";
            cmbMethod.ValueMember = "Value";
        }

        public void LoadPayments(IEnumerable<PaymentDto> items)
        {
            var displayList = items.Select(p => new
            {
                p.Id,
                Client = p.SubscriptionDisplayName,
                Date = p.Date.ToString("yyyy-MM-dd"),
                p.Amount,
                Method = EnumHelper.GetDescription(p.Method)
            }).ToList();

            dgvPayments.DataSource = displayList;
        }




        public void LoadSubscriptions(IEnumerable<SubscriptionDto> items)
        {
            var list = items.ToList();
            cmbSubscriptions.DataSource = list;
            cmbSubscriptions.DisplayMember = "DisplayName";
            cmbSubscriptions.ValueMember = "Id";
        }


        public void SetFields(PaymentDto dto)
        {
            cmbSubscriptions.SelectedValue = dto.SubscriptionId;
            dtpDate.Value = dto.Date;
            numAmount.Value = dto.Amount;
            cmbMethod.SelectedItem = dto.Method;
            UpdateButtonStates();
        }

        public void ClearForm()
        {
            txtSearch.Clear();
            chkSearchAll.Checked = false;
            cmbSubscriptions.SelectedIndex = -1;
            cmbMethod.SelectedIndex = -1;
            dtpDate.Value = DateTime.Today;
            numAmount.Value = 0;
            dgvPayments.ClearSelection();
            UpdateButtonStates();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Payments", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #region Event Handlers

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            if (!ValidatePaymentInput()) return;
            CreateClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (SelectedPaymentId == -1)
            {
                ShowMessage("Please select a payment to update.");
                return;
            }

            if (!ValidatePaymentInput()) return;
            UpdateClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (SelectedPaymentId == -1)
            {
                ShowMessage("Please select a payment to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this payment?", "Confirm", MessageBoxButtons.YesNo);
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

        private void DgvPayments_SelectionChanged(object sender, EventArgs e)
        {
            PaymentSelected?.Invoke(this, EventArgs.Empty);
            UpdateButtonStates();
        }

        private void CmbSubscriptions_SelectedIndexChanged(object sender, EventArgs e) => UpdateButtonStates();
        private void CmbMethod_SelectedIndexChanged(object sender, EventArgs e) => UpdateButtonStates();
        private void NumAmount_ValueChanged(object sender, EventArgs e) => UpdateButtonStates();

        #endregion

        #region Validation Methods

        private bool ValidatePaymentInput(bool silent = false)
        {
            if (cmbSubscriptions.SelectedItem == null)
            {
                if (!silent) ShowMessage("Please select a subscription.");
                return false;
            }

            if (cmbMethod.SelectedItem == null)
            {
                if (!silent) ShowMessage("Please select a payment method.");
                return false;
            }

            if (numAmount.Value <= 0)
            {
                if (!silent) ShowMessage("Payment amount must be greater than 0.");
                return false;
            }

            var selectedYear = dtpDate.Value.Year;
            var currentYear = DateTime.Now.Year;
            if (selectedYear != currentYear && selectedYear != currentYear - 1)
            {
                if (!silent) ShowMessage("Only payments from the current or previous year are allowed.");
                return false;
            }

            return true;
        }

        #endregion

        private void UpdateButtonStates()
        {
            bool hasValidInput = ValidatePaymentInput(silent: true);
            bool paymentSelected = SelectedPaymentId != -1;

            btnCreate.Enabled = hasValidInput && !paymentSelected;
            btnUpdate.Enabled = hasValidInput && paymentSelected;
            btnDelete.Enabled = paymentSelected;
        }
    }
}
