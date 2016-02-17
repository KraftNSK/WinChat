namespace WinChat
{
    partial class frmMain
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
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mEnter = new System.Windows.Forms.ToolStripMenuItem();
            this.mRegistration = new System.Windows.Forms.ToolStripMenuItem();
            this.mExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mClose = new System.Windows.Forms.ToolStripMenuItem();
            this.txtURL = new System.Windows.Forms.ToolStripTextBox();
            this.rtbChat = new System.Windows.Forms.RichTextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.txtURL});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(855, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mEnter,
            this.mRegistration,
            this.mExit,
            this.toolStripMenuItem1,
            this.mClose});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(38, 23);
            this.файлToolStripMenuItem.Text = "Чат";
            // 
            // mEnter
            // 
            this.mEnter.Name = "mEnter";
            this.mEnter.Size = new System.Drawing.Size(143, 22);
            this.mEnter.Text = "Войти";
            this.mEnter.Click += new System.EventHandler(this.mEnter_Click);
            // 
            // mRegistration
            // 
            this.mRegistration.Name = "mRegistration";
            this.mRegistration.Size = new System.Drawing.Size(143, 22);
            this.mRegistration.Text = "Регистрация";
            this.mRegistration.Click += new System.EventHandler(this.mRegistration_Click);
            // 
            // mExit
            // 
            this.mExit.Name = "mExit";
            this.mExit.Size = new System.Drawing.Size(143, 22);
            this.mExit.Text = "Выйти";
            this.mExit.Visible = false;
            this.mExit.Click += new System.EventHandler(this.mExit_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(140, 6);
            // 
            // mClose
            // 
            this.mClose.Name = "mClose";
            this.mClose.Size = new System.Drawing.Size(143, 22);
            this.mClose.Text = "Закрыть";
            this.mClose.Click += new System.EventHandler(this.mClose_Click);
            // 
            // txtURL
            // 
            this.txtURL.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.txtURL.AutoToolTip = true;
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(200, 23);
            this.txtURL.Text = "http://localhost:23310/";
            this.txtURL.ToolTipText = "Адрес чата";
            this.txtURL.TextChanged += new System.EventHandler(this.txtURL_TextChanged);
            // 
            // rtbChat
            // 
            this.rtbChat.BackColor = System.Drawing.Color.Azure;
            this.rtbChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtbChat.Location = new System.Drawing.Point(12, 53);
            this.rtbChat.Name = "rtbChat";
            this.rtbChat.ReadOnly = true;
            this.rtbChat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbChat.Size = new System.Drawing.Size(831, 293);
            this.rtbChat.TabIndex = 1;
            this.rtbChat.Text = "";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLogin.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblLogin.Location = new System.Drawing.Point(12, 30);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(167, 17);
            this.lblLogin.TabIndex = 2;
            this.lblLogin.Text = "Вы не авторизованы!";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Enabled = false;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbl1.Location = new System.Drawing.Point(9, 349);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(163, 17);
            this.lbl1.TabIndex = 2;
            this.lbl1.Text = "Введите сообщение:";
            // 
            // txtMessage
            // 
            this.txtMessage.Enabled = false;
            this.txtMessage.Location = new System.Drawing.Point(12, 369);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(675, 20);
            this.txtMessage.TabIndex = 3;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Enabled = false;
            this.btnSendMessage.Location = new System.Drawing.Point(693, 367);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(150, 23);
            this.btnSendMessage.TabIndex = 4;
            this.btnSendMessage.Text = "Отправить";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnSendMessage;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(855, 401);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.rtbChat);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "WinChat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mEnter;
        private System.Windows.Forms.ToolStripMenuItem mExit;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mClose;
        private System.Windows.Forms.RichTextBox rtbChat;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.ToolStripMenuItem mRegistration;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSendMessage;
        public System.Windows.Forms.ToolStripTextBox txtURL;
    }
}

