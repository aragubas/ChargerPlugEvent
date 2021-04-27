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


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ChargerPlugEvent
{
    public partial class Overlay : Form
    {
        public bool ShowOverlayTrigger;

        public SoundPlayer PlugInSound;
        public SoundPlayer UnplugSound;
        public bool StateChange;
        public bool LastState;
        public bool InSound = true;
        public bool ShowBatteryPercentage;
        public bool ShowBatteryPercentageWhenFull;
        public bool ShowBatteryFull;
        public bool OutSound;
        public int BatteryFullLevel = 97;
        public int BorderWidth = 1;
        public float AnimationSpeed = 0.2f;
        public int FontSize = 18;
        public string ChargerPlugText = "Charging";
        public string ChargerUnplugText = "Unplugged";
        public string BatteryFullText = "Battery Full";
        public Color TextColor = Color.White;
        public Color BackgroundColor = Color.DimGray;
        public Color BorderColor = Color.Black;
        public string TextFont = "Segoe UI";
        string DisplayText = "";

        // Make the Window Click-Trough-able
        const int GWL_EXSTYLE = -20;
        const int WS_EX_LAYERED = 0x80000;
        const int WS_EX_TRANSPARENT = 0x20;
        private const int WS_EX_NOACTIVATE = 0x08000000;


        public Overlay()
        {            
            InitializeComponent();

            // Enable Double Buffer
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

            
        }

        // Don't unfocus other applications when opening
        protected override CreateParams CreateParams
        {
            get
            {
                var createParams = base.CreateParams;

                createParams.ExStyle |= WS_EX_NOACTIVATE | WS_EX_TRANSPARENT | WS_EX_LAYERED;
                createParams.Style = 0x20;

                return createParams;
            }
        }


        private void VisibilityTimer_Tick(object sender, EventArgs e)
        {
            Opacity -= 0.1;

            if (Opacity <= 0)
            {
                Visible = false;
                FadeOut.Stop();
            }
        }

        public void ShowOverlay()
        {
            if (Opacity > 0)
            {
                Refresh();
                Opacity = 0.8;
                FadeIn.Stop();
                FadeOut.Stop();
                WaitUntilFadeOut.Start();
            }
            TopMost = false;
            CenterToScreen();
            Visible = true;
            Opacity = 0;
            Refresh();
            FadeIn.Start();
            TopMost = true;

        }

        private void Overlay_Load(object sender, EventArgs e)
        {
            Visible = false;
            Opacity = 0;
            BackColor = BackgroundColor;

        }

        public void LoadSounds()
        {
            try
            {
                PlugInSound = new SoundPlayer();
                PlugInSound.SoundLocation = Environment.CurrentDirectory + "\\plug.wav";
                PlugInSound.Load();
                Console.WriteLine("Plug sound loaded");

                if (OutSound)
                {
                    UnplugSound = new SoundPlayer();
                    UnplugSound.SoundLocation = Environment.CurrentDirectory + "\\unplug.wav";
                    UnplugSound.Load();
                    Console.WriteLine("Unplug sound loaded");
                }

            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Sound Files not found\n\nArquivos de som não encontrado\n\nArchivo de sonido no encontrado\n\nサウンドファイルが見つかりません\n\n找不到聲音文件", "ChargerPlugEvent");
                Environment.Exit(0);
            }

        }

        private void Update_Tick(object sender, EventArgs e)
        {
            Boolean isRunningOnBattery = (SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Offline);

            if (isRunningOnBattery != LastState)
            {
                StateChange = true;
                LastState = isRunningOnBattery;
            }

            if (StateChange)
            {
                StateChange = false;

                if (isRunningOnBattery)
                {
                    if (OutSound) 
                    { 
                        UnplugSound.Play();
                        DisplayText = ChargerUnplugText;
                        ShowOverlay();

                    }

                }
                else
                {
                    if (InSound) { PlugInSound.Play(); }
                    DisplayText = ChargerPlugText;
                    ShowOverlay();

                    // UnplugSound
                }

            }

        }

        private void WaitUntilFadeOut_Tick(object sender, EventArgs e)
        {
            FadeOut.Start();
            WaitUntilFadeOut.Stop();
        }

        private void FadeIn_Tick(object sender, EventArgs e)
        {
            Opacity += 0.2;

            if (Opacity >= 0.8)
            {
                WaitUntilFadeOut.Start();
                FadeIn.Stop();
            }

        }

        private void Overlay_Paint(object sender, PaintEventArgs e)
        {
            StringFormat ceira = new StringFormat();
            ceira.Alignment = StringAlignment.Center;
            ceira.LineAlignment = StringAlignment.Center;
            string TextToDisplay = DisplayText;
            
            // Aways show percentage when unplugging
            if (ShowBatteryPercentage)
            {
                if (TextToDisplay == ChargerUnplugText)
                {
                    PowerStatus p = SystemInformation.PowerStatus;
                    int BatteryLevel = (int)(p.BatteryLifePercent * 100);

                    TextToDisplay += " " + BatteryLevel + "%";

                }
                else // Show Percentage when plugging Or Show battery full
                {
                    if (ShowBatteryFull)
                    {
                        PowerStatus p = SystemInformation.PowerStatus;
                        int BatteryLevel = (int)(p.BatteryLifePercent * 100);
                        bool BatteryIsIndedFull = BatteryLevel >= BatteryFullLevel;

                        // Replace text with Battery Full Text (if enabled)
                        if (ShowBatteryFull && BatteryLevel >= BatteryFullLevel)
                        {
                            TextToDisplay = BatteryFullText;
                        }


                        // Add battery percentage to text
                        if (ShowBatteryPercentage && !ShowBatteryFull || ShowBatteryFull && !BatteryIsIndedFull)
                        {
                            TextToDisplay += " " + BatteryLevel + "%";

                        }

                    }

                }

            }

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            // Draw Border
            Pen BorderPen = new Pen(new SolidBrush(BorderColor), BorderWidth);
            e.Graphics.DrawRectangle(BorderPen, new Rectangle(0, 0, Width - (int)BorderPen.Width, Height - (int)BorderPen.Width));

            // Draw Text
            e.Graphics.DrawString(TextToDisplay, new Font(TextFont, FontSize), new SolidBrush(TextColor), new Rectangle(0, 0, Width, Height), ceira);
        }


    }
}
