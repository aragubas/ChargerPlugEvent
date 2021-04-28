using TaiyouUI;

namespace Installer
{
    partial class LanguageSelection
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.TitleLanguageSelector = new System.Windows.Forms.Label();
            this.AcceptButton = new TaiyouUI.taiyouButton();
            this.AvaliableLanguagesList = new TaiyouUI.taiyouListBox();
            this.SelectLangTip = new System.Windows.Forms.Label();
            this.CenterPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.CenterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TitleLanguageSelector);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 30);
            this.panel1.TabIndex = 0;
            // 
            // TitleLanguageSelector
            // 
            this.TitleLanguageSelector.AutoSize = true;
            this.TitleLanguageSelector.Dock = System.Windows.Forms.DockStyle.Left;
            this.TitleLanguageSelector.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.TitleLanguageSelector.Location = new System.Drawing.Point(0, 0);
            this.TitleLanguageSelector.Name = "TitleLanguageSelector";
            this.TitleLanguageSelector.Size = new System.Drawing.Size(333, 25);
            this.TitleLanguageSelector.TabIndex = 0;
            this.TitleLanguageSelector.Text = "Instalation -> Set Up -> Select Language";
            // 
            // AcceptButton
            // 
            this.AcceptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AcceptButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AcceptButton.Location = new System.Drawing.Point(380, 298);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(101, 27);
            this.AcceptButton.TabIndex = 1;
            this.AcceptButton.Text = "Accept";
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // AvaliableLanguagesList
            // 
            this.AvaliableLanguagesList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AvaliableLanguagesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AvaliableLanguagesList.FormattingEnabled = true;
            this.AvaliableLanguagesList.Location = new System.Drawing.Point(0, 29);
            this.AvaliableLanguagesList.Name = "AvaliableLanguagesList";
            this.AvaliableLanguagesList.Size = new System.Drawing.Size(336, 185);
            this.AvaliableLanguagesList.TabIndex = 2;
            // 
            // SelectLangTip
            // 
            this.SelectLangTip.Dock = System.Windows.Forms.DockStyle.Top;
            this.SelectLangTip.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.SelectLangTip.Location = new System.Drawing.Point(0, 0);
            this.SelectLangTip.Name = "SelectLangTip";
            this.SelectLangTip.Size = new System.Drawing.Size(336, 29);
            this.SelectLangTip.TabIndex = 3;
            this.SelectLangTip.Text = "Select a language below and click \'Accept\'";
            this.SelectLangTip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CenterPanel
            // 
            this.CenterPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CenterPanel.Controls.Add(this.AvaliableLanguagesList);
            this.CenterPanel.Controls.Add(this.SelectLangTip);
            this.CenterPanel.Location = new System.Drawing.Point(74, 57);
            this.CenterPanel.Name = "CenterPanel";
            this.CenterPanel.Size = new System.Drawing.Size(336, 214);
            this.CenterPanel.TabIndex = 4;
            // 
            // LanguageSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CenterPanel);
            this.Controls.Add(this.AcceptButton);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "LanguageSelection";
            this.Size = new System.Drawing.Size(484, 328);
            this.Load += new System.EventHandler(this.LanguageSelection_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.CenterPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label TitleLanguageSelector;
        private taiyouButton AcceptButton;
        private taiyouListBox AvaliableLanguagesList;
        private System.Windows.Forms.Label SelectLangTip;
        private System.Windows.Forms.Panel CenterPanel;
    }
}
