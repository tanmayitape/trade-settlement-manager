namespace TradeSettlementManager
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtTradeRef = new System.Windows.Forms.TextBox();
            this.txtCounterparty = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtCurrency = new System.Windows.Forms.TextBox();
            this.dateSettlement = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnResolve = new System.Windows.Forms.Button();
            this.btnFail = new System.Windows.Forms.Button();
            this.btnBatch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblTradeRef = new System.Windows.Forms.Label();
            this.lblCounterparty = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            // lblTradeRef
            this.lblTradeRef.Location = new System.Drawing.Point(12, 15);
            this.lblTradeRef.Size = new System.Drawing.Size(80, 20);
            this.lblTradeRef.Text = "Trade Ref:";

            // txtTradeRef
            this.txtTradeRef.Location = new System.Drawing.Point(100, 12);
            this.txtTradeRef.Size = new System.Drawing.Size(150, 22);
            this.txtTradeRef.Name = "txtTradeRef";

            // lblCounterparty
            this.lblCounterparty.Location = new System.Drawing.Point(12, 45);
            this.lblCounterparty.Size = new System.Drawing.Size(80, 20);
            this.lblCounterparty.Text = "Counterparty:";

            // txtCounterparty
            this.txtCounterparty.Location = new System.Drawing.Point(100, 42);
            this.txtCounterparty.Size = new System.Drawing.Size(150, 22);
            this.txtCounterparty.Name = "txtCounterparty";

            // lblAmount
            this.lblAmount.Location = new System.Drawing.Point(12, 75);
            this.lblAmount.Size = new System.Drawing.Size(80, 20);
            this.lblAmount.Text = "Amount:";

            // txtAmount
            this.txtAmount.Location = new System.Drawing.Point(100, 72);
            this.txtAmount.Size = new System.Drawing.Size(150, 22);
            this.txtAmount.Name = "txtAmount";

            // lblCurrency
            this.lblCurrency.Location = new System.Drawing.Point(270, 75);
            this.lblCurrency.Size = new System.Drawing.Size(60, 20);
            this.lblCurrency.Text = "Currency:";

            // txtCurrency
            this.txtCurrency.Location = new System.Drawing.Point(335, 72);
            this.txtCurrency.Size = new System.Drawing.Size(60, 22);
            this.txtCurrency.Name = "txtCurrency";

            // lblDate
            this.lblDate.Location = new System.Drawing.Point(12, 105);
            this.lblDate.Size = new System.Drawing.Size(80, 20);
            this.lblDate.Text = "Settle Date:";

            // dateSettlement
            this.dateSettlement.Location = new System.Drawing.Point(100, 102);
            this.dateSettlement.Size = new System.Drawing.Size(180, 22);
            this.dateSettlement.Name = "dateSettlement";

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(12, 135);
            this.btnAdd.Size = new System.Drawing.Size(120, 30);
            this.btnAdd.Text = "Add Settlement";
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnResolve
            this.btnResolve.Location = new System.Drawing.Point(145, 135);
            this.btnResolve.Size = new System.Drawing.Size(90, 30);
            this.btnResolve.Text = "Resolve";
            this.btnResolve.Name = "btnResolve";
            this.btnResolve.Click += new System.EventHandler(this.btnResolve_Click);

            // btnFail
            this.btnFail.Location = new System.Drawing.Point(248, 135);
            this.btnFail.Size = new System.Drawing.Size(100, 30);
            this.btnFail.Text = "Mark Failed";
            this.btnFail.Name = "btnFail";
            this.btnFail.Click += new System.EventHandler(this.btnFail_Click);

            // btnBatch
            this.btnBatch.Location = new System.Drawing.Point(361, 135);
            this.btnBatch.Size = new System.Drawing.Size(90, 30);
            this.btnBatch.Text = "Run Batch";
            this.btnBatch.Name = "btnBatch";
            this.btnBatch.Click += new System.EventHandler(this.btnBatch_Click);

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(464, 135);
            this.btnRefresh.Size = new System.Drawing.Size(80, 30);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // lblCount
            this.lblCount.Location = new System.Drawing.Point(12, 175);
            this.lblCount.Size = new System.Drawing.Size(200, 20);
            this.lblCount.Text = "Total Records: 0";
            this.lblCount.Name = "lblCount";

            // dataGridView1
            this.dataGridView1.Location = new System.Drawing.Point(12, 198);
            this.dataGridView1.Size = new System.Drawing.Size(760, 350);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // Form1
            this.ClientSize = new System.Drawing.Size(800, 580);
            this.Text = "Trade Settlement Manager";
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);

            this.Controls.Add(this.lblTradeRef);
            this.Controls.Add(this.txtTradeRef);
            this.Controls.Add(this.lblCounterparty);
            this.Controls.Add(this.txtCounterparty);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblCurrency);
            this.Controls.Add(this.txtCurrency);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dateSettlement);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnResolve);
            this.Controls.Add(this.btnFail);
            this.Controls.Add(this.btnBatch);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.dataGridView1);

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtTradeRef;
        private System.Windows.Forms.TextBox txtCounterparty;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtCurrency;
        private System.Windows.Forms.DateTimePicker dateSettlement;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnResolve;
        private System.Windows.Forms.Button btnFail;
        private System.Windows.Forms.Button btnBatch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblTradeRef;
        private System.Windows.Forms.Label lblCounterparty;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.Label lblDate;
    }
}