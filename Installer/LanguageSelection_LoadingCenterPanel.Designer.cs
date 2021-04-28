namespace Installer
{
    partial class LanguageSelection_LoadingCenterPanel
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
            this.LoadingTextLabel = new System.Windows.Forms.Label();
            this.LangFileProgressBar = new System.Windows.Forms.ProgressBar();
            this.LoadLanguageFile = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // LoadingTextLabel
            // 
            this.LoadingTextLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.LoadingTextLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LoadingTextLabel.Location = new System.Drawing.Point(0, 0);
            this.LoadingTextLabel.Name = "LoadingTextLabel";
            this.LoadingTextLabel.Size = new System.Drawing.Size(344, 41);
            this.LoadingTextLabel.TabIndex = 0;
            this.LoadingTextLabel.Text = "Loading language file...";
            this.LoadingTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LangFileProgressBar
            // 
            this.LangFileProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LangFileProgressBar.Location = new System.Drawing.Point(0, 133);
            this.LangFileProgressBar.Name = "LangFileProgressBar";
            this.LangFileProgressBar.Size = new System.Drawing.Size(344, 21);
            this.LangFileProgressBar.TabIndex = 1;
            // 
            // LoadLanguageFile
            // 
            this.LoadLanguageFile.WorkerReportsProgress = true;
            this.LoadLanguageFile.DoWork += new System.ComponentModel.DoWorkEventHandler(this.LoadLanguageFile_DoWork);
            this.LoadLanguageFile.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.LoadLanguageFile_ProgressChanged);
            this.LoadLanguageFile.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.LoadLanguageFile_RunWorkerCompleted);
            // 
            // LanguageSelection_LoadingCenterPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LangFileProgressBar);
            this.Controls.Add(this.LoadingTextLabel);
            this.Name = "LanguageSelection_LoadingCenterPanel";
            this.Size = new System.Drawing.Size(344, 154);
            this.Load += new System.EventHandler(this.LanguageSelection_LoadingCenterPanel_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LoadingTextLabel;
        private System.Windows.Forms.ProgressBar LangFileProgressBar;
        private System.ComponentModel.BackgroundWorker LoadLanguageFile;
    }
}
