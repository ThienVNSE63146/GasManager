namespace Gas
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xăngDầuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nợToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quanToolStripMenuItem,
            this.nợToolStripMenuItem,
            this.trảToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(414, 42);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quanToolStripMenuItem
            // 
            this.quanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kháchHàngToolStripMenuItem,
            this.xăngDầuToolStripMenuItem});
            this.quanToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quanToolStripMenuItem.Name = "quanToolStripMenuItem";
            this.quanToolStripMenuItem.Size = new System.Drawing.Size(119, 36);
            this.quanToolStripMenuItem.Text = "Quản Lý";
            // 
            // kháchHàngToolStripMenuItem
            // 
            this.kháchHàngToolStripMenuItem.Name = "kháchHàngToolStripMenuItem";
            this.kháchHàngToolStripMenuItem.Size = new System.Drawing.Size(227, 36);
            this.kháchHàngToolStripMenuItem.Text = "Khách Hàng";
            this.kháchHàngToolStripMenuItem.Click += new System.EventHandler(this.kháchHàngToolStripMenuItem_Click);
            // 
            // xăngDầuToolStripMenuItem
            // 
            this.xăngDầuToolStripMenuItem.Name = "xăngDầuToolStripMenuItem";
            this.xăngDầuToolStripMenuItem.Size = new System.Drawing.Size(227, 36);
            this.xăngDầuToolStripMenuItem.Text = "Xăng Dầu";
            this.xăngDầuToolStripMenuItem.Click += new System.EventHandler(this.xăngDầuToolStripMenuItem_Click);
            // 
            // nợToolStripMenuItem
            // 
            this.nợToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nợToolStripMenuItem.Name = "nợToolStripMenuItem";
            this.nợToolStripMenuItem.Size = new System.Drawing.Size(59, 36);
            this.nợToolStripMenuItem.Text = "Nợ";
            this.nợToolStripMenuItem.Click += new System.EventHandler(this.nợToolStripMenuItem_Click);
            // 
            // trảToolStripMenuItem
            // 
            this.trảToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trảToolStripMenuItem.Name = "trảToolStripMenuItem";
            this.trảToolStripMenuItem.Size = new System.Drawing.Size(58, 36);
            this.trảToolStripMenuItem.Text = "Trả";
            this.trảToolStripMenuItem.Click += new System.EventHandler(this.trảToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 319);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Main";
            this.Text = "Gas Station";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xăngDầuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nợToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trảToolStripMenuItem;
    }
}

