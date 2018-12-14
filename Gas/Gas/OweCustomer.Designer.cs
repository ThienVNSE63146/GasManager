namespace Gas
{
    partial class OweCustomer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OweCustomer));
            this.btnAddOwe = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtMonth = new System.Windows.Forms.TextBox();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddOwe
            // 
            this.btnAddOwe.Image = ((System.Drawing.Image)(resources.GetObject("btnAddOwe.Image")));
            this.btnAddOwe.Location = new System.Drawing.Point(654, 83);
            this.btnAddOwe.Name = "btnAddOwe";
            this.btnAddOwe.Size = new System.Drawing.Size(64, 60);
            this.btnAddOwe.TabIndex = 22;
            this.btnAddOwe.UseVisualStyleBackColor = true;
            this.btnAddOwe.Click += new System.EventHandler(this.btnAddOwe_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(94, 295);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(608, 224);
            this.dataGridView1.TabIndex = 21;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(304, 222);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(159, 23);
            this.btnSearch.TabIndex = 20;
            this.btnSearch.Text = "Tìm Kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnSearch_MouseClick);
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(252, 167);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(298, 20);
            this.txtYear.TabIndex = 19;
            this.txtYear.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtYear_KeyUp);
            // 
            // txtMonth
            // 
            this.txtMonth.Location = new System.Drawing.Point(252, 140);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(298, 20);
            this.txtMonth.TabIndex = 18;
            this.txtMonth.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMonth_KeyUp);
            // 
            // txtDay
            // 
            this.txtDay.Location = new System.Drawing.Point(252, 107);
            this.txtDay.Name = "txtDay";
            this.txtDay.Size = new System.Drawing.Size(298, 20);
            this.txtDay.TabIndex = 17;
            this.txtDay.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDay_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(166, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Năm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(160, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Tháng ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(166, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Ngày ";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblName.Location = new System.Drawing.Point(301, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(155, 18);
            this.lblName.TabIndex = 23;
            this.lblName.Text = "TÊN KHÁCH HÀNG";
            // 
            // OweCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 548);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnAddOwe);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.txtMonth);
            this.Controls.Add(this.txtDay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "OweCustomer";
            this.Text = "OweCustomer";
            this.Load += new System.EventHandler(this.OweCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddOwe;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.TextBox txtMonth;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblName;
    }
}