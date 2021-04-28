using TaiyouUI;

namespace Installer
{
    partial class InstallerPage1
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
            this.components = new System.ComponentModel.Container();
            this.MainLogo = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.InstallExtraPage = new System.Windows.Forms.Panel();
            this.InstallExtraPageAnimator = new System.Windows.Forms.Timer(this.components);
            this.TitlePanel = new System.Windows.Forms.Panel();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.Instalation = new System.ComponentModel.BackgroundWorker();
            this.NextStepDelay = new System.Windows.Forms.Timer(this.components);
            this.StatusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MainLogo)).BeginInit();
            this.TitlePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainLogo
            // 
            this.MainLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainLogo.Image = global::Installer.Properties.Resources.ChargerPlugEventLogo;
            this.MainLogo.Location = new System.Drawing.Point(120, 70);
            this.MainLogo.Name = "MainLogo";
            this.MainLogo.Size = new System.Drawing.Size(261, 212);
            this.MainLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.MainLogo.TabIndex = 0;
            this.MainLogo.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 324);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(500, 10);
            this.progressBar1.TabIndex = 2;
            // 
            // InstallExtraPage
            // 
            this.InstallExtraPage.Location = new System.Drawing.Point(15, 95);
            this.InstallExtraPage.Name = "InstallExtraPage";
            this.InstallExtraPage.Size = new System.Drawing.Size(86, 50);
            this.InstallExtraPage.TabIndex = 3;
            this.InstallExtraPage.Visible = false;
            // 
            // InstallExtraPageAnimator
            // 
            this.InstallExtraPageAnimator.Enabled = true;
            this.InstallExtraPageAnimator.Interval = 20;
            this.InstallExtraPageAnimator.Tick += new System.EventHandler(this.LanguageWaxAnimator_Tick);
            // 
            // TitlePanel
            // 
            this.TitlePanel.Controls.Add(this.TitleLabel);
            this.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitlePanel.Location = new System.Drawing.Point(0, 0);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(500, 30);
            this.TitlePanel.TabIndex = 4;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.TitleLabel.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.TitleLabel.Location = new System.Drawing.Point(0, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(176, 25);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Instalation -> Set Up";
            // 
            // Instalation
            // 
            this.Instalation.WorkerReportsProgress = true;
            this.Instalation.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Instalation_DoWork);
            this.Instalation.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Instalation_ProgressChanged);
            // 
            // NextStepDelay
            // 
            this.NextStepDelay.Interval = 1200;
            this.NextStepDelay.Tick += new System.EventHandler(this.NextStepDelay_Tick);
            // 
            // StatusLabel
            // 
            this.StatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(2, 308);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(38, 13);
            this.StatusLabel.TabIndex = 5;
            this.StatusLabel.Text = "Ready";
            // 
            // InstallerPage1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.InstallExtraPage);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.MainLogo);
            this.Controls.Add(this.TitlePanel);
            this.Controls.Add(this.StatusLabel);
            this.DoubleBuffered = true;
            this.Name = "InstallerPage1";
            this.Size = new System.Drawing.Size(500, 334);
            this.Load += new System.EventHandler(this.InstallerPage1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainLogo)).EndInit();
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox MainLogo;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel InstallExtraPage;
        private System.Windows.Forms.Timer InstallExtraPageAnimator;
        private System.Windows.Forms.Panel TitlePanel;
        private System.Windows.Forms.Label TitleLabel;
        private System.ComponentModel.BackgroundWorker Instalation;
        public System.Windows.Forms.Timer NextStepDelay;
        private System.Windows.Forms.Label StatusLabel;
    }
}
