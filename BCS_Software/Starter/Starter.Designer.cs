namespace BCS_Software
{
    partial class Starter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Starter));
            this.lblIP = new System.Windows.Forms.Label();
            this.checkBoxHost = new System.Windows.Forms.CheckBox();
            this.lblState = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.checkBoxDebug = new System.Windows.Forms.CheckBox();
            this.textBoxPartnerIP = new System.Windows.Forms.TextBox();
            this.rdStarter = new System.Windows.Forms.RadioButton();
            this.rdSecond = new System.Windows.Forms.RadioButton();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.textBoxYourName = new System.Windows.Forms.TextBox();
            this.numericUpDownYourScore = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownPort = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYourScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIP
            // 
            resources.ApplyResources(this.lblIP, "lblIP");
            this.lblIP.Name = "lblIP";
            // 
            // checkBoxHost
            // 
            resources.ApplyResources(this.checkBoxHost, "checkBoxHost");
            this.checkBoxHost.Name = "checkBoxHost";
            this.checkBoxHost.UseVisualStyleBackColor = true;
            this.checkBoxHost.CheckedChanged += new System.EventHandler(this.CheckHost_CheckedChanged);
            // 
            // lblState
            // 
            resources.ApplyResources(this.lblState, "lblState");
            this.lblState.Name = "lblState";
            // 
            // labelVersion
            // 
            resources.ApplyResources(this.labelVersion, "labelVersion");
            this.labelVersion.Name = "labelVersion";
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonStart
            // 
            resources.ApplyResources(this.buttonStart, "buttonStart");
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // checkBoxDebug
            // 
            resources.ApplyResources(this.checkBoxDebug, "checkBoxDebug");
            this.checkBoxDebug.Name = "checkBoxDebug";
            this.checkBoxDebug.UseVisualStyleBackColor = true;
            this.checkBoxDebug.CheckedChanged += new System.EventHandler(this.CheckBoxDebug_CheckedChanged);
            // 
            // textBoxPartnerIP
            // 
            resources.ApplyResources(this.textBoxPartnerIP, "textBoxPartnerIP");
            this.textBoxPartnerIP.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxPartnerIP.Name = "textBoxPartnerIP";
            this.textBoxPartnerIP.Enter += new System.EventHandler(this.TextBoxPartnerIP_Enter);
            this.textBoxPartnerIP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxIP_KeyDown);
            // 
            // rdStarter
            // 
            resources.ApplyResources(this.rdStarter, "rdStarter");
            this.rdStarter.Name = "rdStarter";
            this.rdStarter.UseVisualStyleBackColor = true;
            // 
            // rdSecond
            // 
            resources.ApplyResources(this.rdSecond, "rdSecond");
            this.rdSecond.Checked = true;
            this.rdSecond.Name = "rdSecond";
            this.rdSecond.TabStop = true;
            this.rdSecond.UseVisualStyleBackColor = true;
            // 
            // buttonSettings
            // 
            resources.ApplyResources(this.buttonSettings, "buttonSettings");
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.ButtonSettings_Click);
            // 
            // textBoxYourName
            // 
            resources.ApplyResources(this.textBoxYourName, "textBoxYourName");
            this.textBoxYourName.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxYourName.Name = "textBoxYourName";
            this.textBoxYourName.Enter += new System.EventHandler(this.TextBoxYourName_Enter);
            // 
            // numericUpDownYourScore
            // 
            resources.ApplyResources(this.numericUpDownYourScore, "numericUpDownYourScore");
            this.numericUpDownYourScore.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownYourScore.Name = "numericUpDownYourScore";
            this.numericUpDownYourScore.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // numericUpDownPort
            // 
            resources.ApplyResources(this.numericUpDownPort, "numericUpDownPort");
            this.numericUpDownPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownPort.Name = "numericUpDownPort";
            this.numericUpDownPort.Value = new decimal(new int[] {
            55515,
            0,
            0,
            0});
            // 
            // Starter
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDownPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdSecond);
            this.Controls.Add(this.rdStarter);
            this.Controls.Add(this.numericUpDownYourScore);
            this.Controls.Add(this.textBoxYourName);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.textBoxPartnerIP);
            this.Controls.Add(this.checkBoxDebug);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.checkBoxHost);
            this.Controls.Add(this.lblIP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Starter";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.Starter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYourScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.CheckBox checkBoxHost;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.CheckBox checkBoxDebug;
        private System.Windows.Forms.TextBox textBoxPartnerIP;
        private System.Windows.Forms.RadioButton rdStarter;
        private System.Windows.Forms.RadioButton rdSecond;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.TextBox textBoxYourName;
        private System.Windows.Forms.NumericUpDown numericUpDownYourScore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownPort;
    }
}