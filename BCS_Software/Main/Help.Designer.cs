namespace BCS_Software
{
    partial class Help
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
            this.listViewHelp = new System.Windows.Forms.ListView();
            this.columnAttacker = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDefender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDamage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnQuote = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewHelp
            // 
            this.listViewHelp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnAttacker,
            this.columnDefender,
            this.columnDamage,
            this.columnQuote});
            this.listViewHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewHelp.FullRowSelect = true;
            this.listViewHelp.Location = new System.Drawing.Point(0, 0);
            this.listViewHelp.MultiSelect = false;
            this.listViewHelp.Name = "listViewHelp";
            this.listViewHelp.Size = new System.Drawing.Size(307, 221);
            this.listViewHelp.TabIndex = 0;
            this.listViewHelp.UseCompatibleStateImageBehavior = false;
            this.listViewHelp.View = System.Windows.Forms.View.Details;
            // 
            // columnAttacker
            // 
            this.columnAttacker.Text = "Angreifer";
            this.columnAttacker.Width = 65;
            // 
            // columnDefender
            // 
            this.columnDefender.Text = "Verteidiger";
            this.columnDefender.Width = 65;
            // 
            // columnDamage
            // 
            this.columnDamage.Text = "Schaden";
            this.columnDamage.Width = 65;
            // 
            // columnQuote
            // 
            this.columnQuote.Text = "Wahrscheinlichkeit";
            this.columnQuote.Width = 105;
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 221);
            this.Controls.Add(this.listViewHelp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Help";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Hilfe";
            this.Load += new System.EventHandler(this.Help_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewHelp;
        private System.Windows.Forms.ColumnHeader columnAttacker;
        private System.Windows.Forms.ColumnHeader columnDefender;
        private System.Windows.Forms.ColumnHeader columnDamage;
        private System.Windows.Forms.ColumnHeader columnQuote;
    }
}