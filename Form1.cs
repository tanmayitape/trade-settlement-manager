using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TradeSettlementManager.Models;
using TradeSettlementManager.Services;

namespace TradeSettlementManager
{
    public partial class Form1 : Form
    {
        private readonly SettlementService _service;

        public Form1()
        {
            InitializeComponent();
            _service = new SettlementService();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSettlements();
        }

        private void LoadSettlements()
        {
            try
            {
                List<Settlement> settlements = _service.GetAllSettlements();
                dataGridView1.DataSource = settlements;
                lblCount.Text = $"Total Records: {settlements.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading settlements: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _service.CreateSettlement(
                    txtTradeRef.Text,
                    txtCounterparty.Text,
                    decimal.Parse(txtAmount.Text),
                    txtCurrency.Text,
                    dateSettlement.Value
                );

                MessageBox.Show("Settlement created successfully.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadSettlements();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnResolve_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a settlement to resolve.",
                                "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["SettlementId"].Value);
                _service.ResolveSettlement(id, "RESOLVED");
                MessageBox.Show("Settlement resolved successfully.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSettlements();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFail_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a settlement to mark as failed.",
                                "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["SettlementId"].Value);
                _service.ResolveSettlement(id, "FAILED");
                MessageBox.Show("Settlement marked as failed.",
                                "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSettlements();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBatch_Click(object sender, EventArgs e)
        {
            try
            {
                int processed = _service.RunBatchProcess();
                MessageBox.Show($"Batch process complete. {processed} settlement(s) resolved.",
                                "Batch Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSettlements();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadSettlements();
        }

        private void ClearForm()
        {
            txtTradeRef.Text = "";
            txtCounterparty.Text = "";
            txtAmount.Text = "";
            txtCurrency.Text = "";
            dateSettlement.Value = DateTime.Today;
        }
    }
}