namespace BCS_Software
{
    partial class StarterSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StarterSettings));
            this.lblSoldier = new System.Windows.Forms.Label();
            this.lblTank = new System.Windows.Forms.Label();
            this.lblJet = new System.Windows.Forms.Label();
            this.pictureTank = new System.Windows.Forms.PictureBox();
            this.pictureSoldier = new System.Windows.Forms.PictureBox();
            this.pictureJet = new System.Windows.Forms.PictureBox();
            this.rdNormalIcons = new System.Windows.Forms.RadioButton();
            this.rdCustomIcons = new System.Windows.Forms.RadioButton();
            this.buttonSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSoldier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureJet)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSoldier
            // 
            this.lblSoldier.AutoSize = true;
            this.lblSoldier.Location = new System.Drawing.Point(9, 64);
            this.lblSoldier.Name = "lblSoldier";
            this.lblSoldier.Size = new System.Drawing.Size(37, 13);
            this.lblSoldier.TabIndex = 2;
            this.lblSoldier.Text = "Soldat";
            // 
            // lblTank
            // 
            this.lblTank.AutoSize = true;
            this.lblTank.Location = new System.Drawing.Point(76, 64);
            this.lblTank.Name = "lblTank";
            this.lblTank.Size = new System.Drawing.Size(40, 13);
            this.lblTank.TabIndex = 3;
            this.lblTank.Text = "Panzer";
            // 
            // lblJet
            // 
            this.lblJet.AutoSize = true;
            this.lblJet.Location = new System.Drawing.Point(146, 64);
            this.lblJet.Name = "lblJet";
            this.lblJet.Size = new System.Drawing.Size(50, 13);
            this.lblJet.TabIndex = 4;
            this.lblJet.Text = "Flugzeug";
            // 
            // pictureTank
            // 
            this.pictureTank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureTank.Location = new System.Drawing.Point(79, 80);
            this.pictureTank.Name = "pictureTank";
            this.pictureTank.Size = new System.Drawing.Size(64, 64);
            this.pictureTank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureTank.TabIndex = 5;
            this.pictureTank.TabStop = false;
            this.pictureTank.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureTank_MouseClick);
            // 
            // pictureSoldier
            // 
            this.pictureSoldier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureSoldier.Location = new System.Drawing.Point(9, 80);
            this.pictureSoldier.Name = "pictureSoldier";
            this.pictureSoldier.Size = new System.Drawing.Size(64, 64);
            this.pictureSoldier.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureSoldier.TabIndex = 6;
            this.pictureSoldier.TabStop = false;
            this.pictureSoldier.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureSoldier_MouseClick);
            // 
            // pictureJet
            // 
            this.pictureJet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureJet.Location = new System.Drawing.Point(149, 80);
            this.pictureJet.Name = "pictureJet";
            this.pictureJet.Size = new System.Drawing.Size(64, 64);
            this.pictureJet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureJet.TabIndex = 7;
            this.pictureJet.TabStop = false;
            this.pictureJet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureJet_MouseClick);
            // 
            // rdNormalIcons
            // 
            this.rdNormalIcons.AutoSize = true;
            this.rdNormalIcons.Checked = true;
            this.rdNormalIcons.Location = new System.Drawing.Point(12, 12);
            this.rdNormalIcons.Name = "rdNormalIcons";
            this.rdNormalIcons.Size = new System.Drawing.Size(149, 17);
            this.rdNormalIcons.TabIndex = 2;
            this.rdNormalIcons.TabStop = true;
            this.rdNormalIcons.Text = "Normale Icons verwenden";
            this.rdNormalIcons.UseVisualStyleBackColor = true;
            // 
            // rdCustomIcons
            // 
            this.rdCustomIcons.AutoSize = true;
            this.rdCustomIcons.Location = new System.Drawing.Point(12, 35);
            this.rdCustomIcons.Name = "rdCustomIcons";
            this.rdCustomIcons.Size = new System.Drawing.Size(143, 17);
            this.rdCustomIcons.TabIndex = 3;
            this.rdCustomIcons.Text = "Eigene Icons verwenden";
            this.rdCustomIcons.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(9, 150);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(204, 23);
            this.buttonSave.TabIndex = 17;
            this.buttonSave.Text = "Speichern und Schließen";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // StarterSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 183);
            this.Controls.Add(this.rdNormalIcons);
            this.Controls.Add(this.rdCustomIcons);
            this.Controls.Add(this.lblSoldier);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.pictureJet);
            this.Controls.Add(this.lblTank);
            this.Controls.Add(this.pictureTank);
            this.Controls.Add(this.pictureSoldier);
            this.Controls.Add(this.lblJet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StarterSettings";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Erweiterte Einstellungen";
            this.Load += new System.EventHandler(this.StarterSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureTank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSoldier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureJet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSoldier;
        private System.Windows.Forms.Label lblTank;
        private System.Windows.Forms.Label lblJet;
        private System.Windows.Forms.PictureBox pictureTank;
        private System.Windows.Forms.PictureBox pictureSoldier;
        private System.Windows.Forms.PictureBox pictureJet;
        private System.Windows.Forms.RadioButton rdNormalIcons;
        private System.Windows.Forms.RadioButton rdCustomIcons;
        private System.Windows.Forms.Button buttonSave;
    }
}