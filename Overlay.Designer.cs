/*
   Copyright 2020 Aragubas/Paulo Otávio de Lima

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
 */

namespace ChargerPlugEvent
{
    partial class Overlay
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
            this.components = new System.ComponentModel.Container();
            this.FadeOut = new System.Windows.Forms.Timer(this.components);
            this.Update = new System.Windows.Forms.Timer(this.components);
            this.FadeIn = new System.Windows.Forms.Timer(this.components);
            this.WaitUntilFadeOut = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // FadeOut
            // 
            this.FadeOut.Interval = 24;
            this.FadeOut.Tick += new System.EventHandler(this.VisibilityTimer_Tick);
            // 
            // Update
            // 
            this.Update.Enabled = true;
            this.Update.Interval = 700;
            this.Update.Tick += new System.EventHandler(this.Update_Tick);
            // 
            // FadeIn
            // 
            this.FadeIn.Interval = 24;
            this.FadeIn.Tick += new System.EventHandler(this.FadeIn_Tick);
            // 
            // WaitUntilFadeOut
            // 
            this.WaitUntilFadeOut.Interval = 1200;
            this.WaitUntilFadeOut.Tick += new System.EventHandler(this.WaitUntilFadeOut_Tick);
            // 
            // Overlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(256, 85);
            this.Font = new System.Drawing.Font("Arial", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Overlay";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChargerPlugEvent";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Overlay_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Overlay_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Overlay_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Timer FadeOut;
        public System.Windows.Forms.Timer Update;
        private System.Windows.Forms.Timer FadeIn;
        private System.Windows.Forms.Timer WaitUntilFadeOut;
    }
}