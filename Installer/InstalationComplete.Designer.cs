using TaiyouUI;

namespace Installer
{
    partial class InstalationComplete
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
            this.TitlePanel = new System.Windows.Forms.Panel();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.MainLogo = new System.Windows.Forms.PictureBox();
            this.InstallCompleteLabel = new System.Windows.Forms.Label();
            this.FinishButton = new TaiyouUI.taiyouButton();
            this.TitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // TitlePanel
            // 
            this.TitlePanel.Controls.Add(this.TitleLabel);
            this.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitlePanel.Location = new System.Drawing.Point(0, 0);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(402, 30);
            this.TitlePanel.TabIndex = 5;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.TitleLabel.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.TitleLabel.Location = new System.Drawing.Point(0, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(200, 25);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Instalation -> Complete";
            // 
            // MainLogo
            // 
            this.MainLogo.Image = global::Installer.Properties.Resources.ChargerPlugEventLogo;
            this.MainLogo.Location = new System.Drawing.Point(5, 36);
            this.MainLogo.Name = "MainLogo";
            this.MainLogo.Size = new System.Drawing.Size(141, 134);
            this.MainLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.MainLogo.TabIndex = 6;
            this.MainLogo.TabStop = false;
            // 
            // InstallCompleteLabel
            // 
            this.InstallCompleteLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InstallCompleteLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstallCompleteLabel.Location = new System.Drawing.Point(152, 36);
            this.InstallCompleteLabel.Name = "InstallCompleteLabel";
            this.InstallCompleteLabel.Size = new System.Drawing.Size(247, 253);
            this.InstallCompleteLabel.TabIndex = 7;
            this.InstallCompleteLabel.Text = "label1";
            // 
            // FinishButton
            // 
            this.FinishButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FinishButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FinishButton.Location = new System.Drawing.Point(306, 292);
            this.FinishButton.Name = "FinishButton";
            this.FinishButton.Size = new System.Drawing.Size(93, 27);
            this.FinishButton.TabIndex = 8;
            this.FinishButton.Text = "Finish";
            this.FinishButton.UseVisualStyleBackColor = true;
            this.FinishButton.Click += new System.EventHandler(this.FinishButton_Click);
            // 
            // InstalationComplete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FinishButton);
            this.Controls.Add(this.InstallCompleteLabel);
            this.Controls.Add(this.MainLogo);
            this.Controls.Add(this.TitlePanel);
            this.DoubleBuffered = true;
            this.Name = "InstalationComplete";
            this.Size = new System.Drawing.Size(402, 322);
            this.Load += new System.EventHandler(this.InstalationComplete_Load);
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TitlePanel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.PictureBox MainLogo;
        private System.Windows.Forms.Label InstallCompleteLabel;
        private taiyouButton FinishButton;
    }
}
