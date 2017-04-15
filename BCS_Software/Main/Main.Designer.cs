namespace BCS_Software
{
    partial class Main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            if (disposing && (_connectionObject != null))
            {
                _connectionObject.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuButtonExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuButtonInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuButtonChat = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.uiTimer = new System.Windows.Forms.Timer(this.components);
            this.labelLifePointsYou = new System.Windows.Forms.Label();
            this.labelLifePointsEnemy = new System.Windows.Forms.Label();
            this.labelYourName = new System.Windows.Forms.Label();
            this.progressLifeBarYou = new System.Windows.Forms.ProgressBar();
            this.progressLifebarEnemy = new System.Windows.Forms.ProgressBar();
            this.labelEnemyName = new System.Windows.Forms.Label();
            this.buttonReady = new System.Windows.Forms.Button();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.labelSoldierEnemy = new System.Windows.Forms.Label();
            this.labelSoldierYou = new System.Windows.Forms.Label();
            this.labelTankYou = new System.Windows.Forms.Label();
            this.labelTankEnemy = new System.Windows.Forms.Label();
            this.labelJetEnemy = new System.Windows.Forms.Label();
            this.labelJetYou = new System.Windows.Forms.Label();
            this.labelPrice1 = new System.Windows.Forms.Label();
            this.labelPrice2 = new System.Windows.Forms.Label();
            this.labelPrice3 = new System.Windows.Forms.Label();
            this.pictureBoxTurnYou = new System.Windows.Forms.PictureBox();
            this.pictureBoxTurnEnemy = new System.Windows.Forms.PictureBox();
            this.pcJetYou = new System.Windows.Forms.PictureBox();
            this.pcTankYou = new System.Windows.Forms.PictureBox();
            this.pcSoldierYou = new System.Windows.Forms.PictureBox();
            this.pcJetEnemy = new System.Windows.Forms.PictureBox();
            this.pcTankEnemy = new System.Windows.Forms.PictureBox();
            this.pcSoldierEnemy = new System.Windows.Forms.PictureBox();
            this.listBoxChatLog = new System.Windows.Forms.ListBox();
            this.buttonChatSend = new System.Windows.Forms.Button();
            this.textBoxChatMessage = new System.Windows.Forms.TextBox();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTurnYou)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTurnEnemy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcJetYou)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcTankYou)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcSoldierYou)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcJetEnemy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcTankEnemy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcSoldierEnemy)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuButtonExit,
            this.menuButtonInfo,
            this.menuButtonChat});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // menuButtonExit
            // 
            this.menuButtonExit.Name = "menuButtonExit";
            resources.ApplyResources(this.menuButtonExit, "menuButtonExit");
            this.menuButtonExit.Click += new System.EventHandler(this.MenuButtonExit_Click);
            // 
            // menuButtonInfo
            // 
            this.menuButtonInfo.Name = "menuButtonInfo";
            resources.ApplyResources(this.menuButtonInfo, "menuButtonInfo");
            this.menuButtonInfo.Click += new System.EventHandler(this.MenuButtonInfo_Click);
            // 
            // menuButtonChat
            // 
            this.menuButtonChat.Name = "menuButtonChat";
            resources.ApplyResources(this.menuButtonChat, "menuButtonChat");
            this.menuButtonChat.Click += new System.EventHandler(this.MenuButtonChat_Click);
            // 
            // mainTimer
            // 
            this.mainTimer.Interval = 1500;
            this.mainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
            // 
            // uiTimer
            // 
            this.uiTimer.Interval = 250;
            this.uiTimer.Tick += new System.EventHandler(this.UITimer_Tick);
            // 
            // labelLifePointsYou
            // 
            resources.ApplyResources(this.labelLifePointsYou, "labelLifePointsYou");
            this.labelLifePointsYou.Name = "labelLifePointsYou";
            // 
            // labelLifePointsEnemy
            // 
            resources.ApplyResources(this.labelLifePointsEnemy, "labelLifePointsEnemy");
            this.labelLifePointsEnemy.Name = "labelLifePointsEnemy";
            // 
            // labelYourName
            // 
            resources.ApplyResources(this.labelYourName, "labelYourName");
            this.labelYourName.Name = "labelYourName";
            // 
            // progressLifeBarYou
            // 
            resources.ApplyResources(this.progressLifeBarYou, "progressLifeBarYou");
            this.progressLifeBarYou.Name = "progressLifeBarYou";
            // 
            // progressLifebarEnemy
            // 
            resources.ApplyResources(this.progressLifebarEnemy, "progressLifebarEnemy");
            this.progressLifebarEnemy.Name = "progressLifebarEnemy";
            // 
            // labelEnemyName
            // 
            resources.ApplyResources(this.labelEnemyName, "labelEnemyName");
            this.labelEnemyName.Name = "labelEnemyName";
            // 
            // buttonReady
            // 
            resources.ApplyResources(this.buttonReady, "buttonReady");
            this.buttonReady.Name = "buttonReady";
            this.buttonReady.UseVisualStyleBackColor = true;
            this.buttonReady.Click += new System.EventHandler(this.ButtonReady_Click);
            // 
            // listBoxLog
            // 
            this.listBoxLog.FormattingEnabled = true;
            resources.ApplyResources(this.listBoxLog, "listBoxLog");
            this.listBoxLog.Name = "listBoxLog";
            // 
            // labelSoldierEnemy
            // 
            resources.ApplyResources(this.labelSoldierEnemy, "labelSoldierEnemy");
            this.labelSoldierEnemy.Name = "labelSoldierEnemy";
            // 
            // labelSoldierYou
            // 
            resources.ApplyResources(this.labelSoldierYou, "labelSoldierYou");
            this.labelSoldierYou.Name = "labelSoldierYou";
            // 
            // labelTankYou
            // 
            resources.ApplyResources(this.labelTankYou, "labelTankYou");
            this.labelTankYou.Name = "labelTankYou";
            // 
            // labelTankEnemy
            // 
            resources.ApplyResources(this.labelTankEnemy, "labelTankEnemy");
            this.labelTankEnemy.Name = "labelTankEnemy";
            // 
            // labelJetEnemy
            // 
            resources.ApplyResources(this.labelJetEnemy, "labelJetEnemy");
            this.labelJetEnemy.Name = "labelJetEnemy";
            // 
            // labelJetYou
            // 
            resources.ApplyResources(this.labelJetYou, "labelJetYou");
            this.labelJetYou.Name = "labelJetYou";
            // 
            // labelPrice1
            // 
            resources.ApplyResources(this.labelPrice1, "labelPrice1");
            this.labelPrice1.Name = "labelPrice1";
            // 
            // labelPrice2
            // 
            resources.ApplyResources(this.labelPrice2, "labelPrice2");
            this.labelPrice2.Name = "labelPrice2";
            // 
            // labelPrice3
            // 
            resources.ApplyResources(this.labelPrice3, "labelPrice3");
            this.labelPrice3.Name = "labelPrice3";
            // 
            // pictureBoxTurnYou
            // 
            this.pictureBoxTurnYou.Image = global::BCS_Software.Resource.yourTurn;
            resources.ApplyResources(this.pictureBoxTurnYou, "pictureBoxTurnYou");
            this.pictureBoxTurnYou.Name = "pictureBoxTurnYou";
            this.pictureBoxTurnYou.TabStop = false;
            // 
            // pictureBoxTurnEnemy
            // 
            this.pictureBoxTurnEnemy.Image = global::BCS_Software.Resource.enemyTurn;
            resources.ApplyResources(this.pictureBoxTurnEnemy, "pictureBoxTurnEnemy");
            this.pictureBoxTurnEnemy.Name = "pictureBoxTurnEnemy";
            this.pictureBoxTurnEnemy.TabStop = false;
            // 
            // pcJetYou
            // 
            this.pcJetYou.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.pcJetYou, "pcJetYou");
            this.pcJetYou.Name = "pcJetYou";
            this.pcJetYou.TabStop = false;
            this.pcJetYou.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PcJetYou_MouseClick);
            this.pcJetYou.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PcJetYou_MouseDown);
            this.pcJetYou.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PcJetYou_MouseUp);
            // 
            // pcTankYou
            // 
            this.pcTankYou.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.pcTankYou, "pcTankYou");
            this.pcTankYou.Name = "pcTankYou";
            this.pcTankYou.TabStop = false;
            this.pcTankYou.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PcTankYou_MouseClick);
            this.pcTankYou.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PcTankYou_MouseDown);
            this.pcTankYou.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PcTankYou_MouseUp);
            // 
            // pcSoldierYou
            // 
            this.pcSoldierYou.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.pcSoldierYou, "pcSoldierYou");
            this.pcSoldierYou.Name = "pcSoldierYou";
            this.pcSoldierYou.TabStop = false;
            this.pcSoldierYou.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PcSoldierYou_MouseClick);
            this.pcSoldierYou.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PcSoldierYou_MouseDown);
            this.pcSoldierYou.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PcSoldierYou_MouseUp);
            // 
            // pcJetEnemy
            // 
            this.pcJetEnemy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.pcJetEnemy, "pcJetEnemy");
            this.pcJetEnemy.Name = "pcJetEnemy";
            this.pcJetEnemy.TabStop = false;
            this.pcJetEnemy.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PcJetEnemy_MouseClick);
            this.pcJetEnemy.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PcJetEnemy_MouseDown);
            this.pcJetEnemy.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PcJetEnemy_MouseUp);
            // 
            // pcTankEnemy
            // 
            this.pcTankEnemy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.pcTankEnemy, "pcTankEnemy");
            this.pcTankEnemy.Name = "pcTankEnemy";
            this.pcTankEnemy.TabStop = false;
            this.pcTankEnemy.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PcTankEnemy_MouseClick);
            this.pcTankEnemy.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PcTankEnemy_MouseDown);
            this.pcTankEnemy.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PcTankEnemy_MouseUp);
            // 
            // pcSoldierEnemy
            // 
            this.pcSoldierEnemy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.pcSoldierEnemy, "pcSoldierEnemy");
            this.pcSoldierEnemy.Name = "pcSoldierEnemy";
            this.pcSoldierEnemy.TabStop = false;
            this.pcSoldierEnemy.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PcSoldierEnemy_MouseClick);
            this.pcSoldierEnemy.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PcSoldierEnemy_MouseDown);
            this.pcSoldierEnemy.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PcSoldierEnemy_MouseUp);
            // 
            // listBoxChatLog
            // 
            this.listBoxChatLog.FormattingEnabled = true;
            resources.ApplyResources(this.listBoxChatLog, "listBoxChatLog");
            this.listBoxChatLog.Name = "listBoxChatLog";
            this.listBoxChatLog.SelectionMode = System.Windows.Forms.SelectionMode.None;
            // 
            // buttonChatSend
            // 
            resources.ApplyResources(this.buttonChatSend, "buttonChatSend");
            this.buttonChatSend.Name = "buttonChatSend";
            this.buttonChatSend.UseVisualStyleBackColor = true;
            this.buttonChatSend.Click += new System.EventHandler(this.ButtonChatSend_Click);
            // 
            // textBoxChatMessage
            // 
            resources.ApplyResources(this.textBoxChatMessage, "textBoxChatMessage");
            this.textBoxChatMessage.Name = "textBoxChatMessage";
            this.textBoxChatMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxChatMessage_KeyDown);
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxChatMessage);
            this.Controls.Add(this.buttonChatSend);
            this.Controls.Add(this.listBoxChatLog);
            this.Controls.Add(this.labelPrice3);
            this.Controls.Add(this.labelPrice2);
            this.Controls.Add(this.labelPrice1);
            this.Controls.Add(this.labelJetYou);
            this.Controls.Add(this.labelJetEnemy);
            this.Controls.Add(this.labelTankEnemy);
            this.Controls.Add(this.labelTankYou);
            this.Controls.Add(this.labelSoldierYou);
            this.Controls.Add(this.labelSoldierEnemy);
            this.Controls.Add(this.buttonReady);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.pictureBoxTurnYou);
            this.Controls.Add(this.pictureBoxTurnEnemy);
            this.Controls.Add(this.pcJetYou);
            this.Controls.Add(this.pcTankYou);
            this.Controls.Add(this.pcSoldierYou);
            this.Controls.Add(this.pcJetEnemy);
            this.Controls.Add(this.pcTankEnemy);
            this.Controls.Add(this.pcSoldierEnemy);
            this.Controls.Add(this.labelLifePointsYou);
            this.Controls.Add(this.labelLifePointsEnemy);
            this.Controls.Add(this.labelYourName);
            this.Controls.Add(this.progressLifeBarYou);
            this.Controls.Add(this.progressLifebarEnemy);
            this.Controls.Add(this.labelEnemyName);
            this.Controls.Add(this.menuStrip);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTurnYou)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTurnEnemy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcJetYou)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcTankYou)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcSoldierYou)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcJetEnemy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcTankEnemy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcSoldierEnemy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuButtonExit;
        private System.Windows.Forms.Timer mainTimer;
        private System.Windows.Forms.ToolStripMenuItem menuButtonInfo;
        private System.Windows.Forms.Timer uiTimer;
        private System.Windows.Forms.PictureBox pictureBoxTurnYou;
        private System.Windows.Forms.PictureBox pictureBoxTurnEnemy;
        private System.Windows.Forms.PictureBox pcJetYou;
        private System.Windows.Forms.PictureBox pcTankYou;
        private System.Windows.Forms.PictureBox pcSoldierYou;
        private System.Windows.Forms.PictureBox pcJetEnemy;
        private System.Windows.Forms.PictureBox pcTankEnemy;
        private System.Windows.Forms.PictureBox pcSoldierEnemy;
        private System.Windows.Forms.Label labelLifePointsYou;
        private System.Windows.Forms.Label labelLifePointsEnemy;
        private System.Windows.Forms.Label labelYourName;
        private System.Windows.Forms.ProgressBar progressLifeBarYou;
        private System.Windows.Forms.ProgressBar progressLifebarEnemy;
        private System.Windows.Forms.Label labelEnemyName;
        private System.Windows.Forms.Button buttonReady;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.Label labelSoldierEnemy;
        private System.Windows.Forms.Label labelSoldierYou;
        private System.Windows.Forms.Label labelTankYou;
        private System.Windows.Forms.Label labelTankEnemy;
        private System.Windows.Forms.Label labelJetEnemy;
        private System.Windows.Forms.Label labelJetYou;
        private System.Windows.Forms.Label labelPrice1;
        private System.Windows.Forms.Label labelPrice2;
        private System.Windows.Forms.Label labelPrice3;
        private System.Windows.Forms.ToolStripMenuItem menuButtonChat;
        private System.Windows.Forms.ListBox listBoxChatLog;
        private System.Windows.Forms.Button buttonChatSend;
        private System.Windows.Forms.TextBox textBoxChatMessage;
    }
}

