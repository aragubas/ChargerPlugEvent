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
        public bool FadeoutWhenClicking = false;
        public bool OutSound;
        public int DetectionDelay = 500;
        public int BatteryFullLevel = 97;
        public int BorderWidth = 1;
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
        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        const int GWL_EXSTYLE = -20;
        const int WS_EX_LAYERED = 0x80000;
        const int WS_EX_TRANSPARENT = 0x20;
        private const int WS_EX_NOACTIVATE = 0x08000000;


        public Overlay()
        {
            var style = GetWindowLong(this.Handle, GWL_EXSTYLE);
            SetWindowLong(this.Handle, GWL_EXSTYLE, style | WS_EX_LAYERED | WS_EX_TRANSPARENT);

            
            InitializeComponent();

            
        }

        // Don't unfocus other applications when opening
        protected override CreateParams CreateParams
        {
            get
            {
                var createParams = base.CreateParams;

                createParams.ExStyle |= WS_EX_NOACTIVATE;
                createParams.Style = 0x20;

                return createParams;
            }
        }


        private void VisibilityTimer_Tick(object sender, EventArgs e)
        {
            Opacity -= 0.1;


            if (Opacity <= 0)
            {
                Opacity = 0;
                Visible = false;
                FadeOut.Stop();
            }
        }

        public void ShowOverlay()
        {
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
            PlugInSound = new SoundPlayer();
            PlugInSound.SoundLocation = Environment.CurrentDirectory + "\\plug.wav";
            Console.WriteLine("Plug sound loaded");

            if (OutSound)
            {
                UnplugSound = new SoundPlayer();
                UnplugSound.SoundLocation = Environment.CurrentDirectory + "\\unplug.wav";
                Console.WriteLine("Unplug sound loaded");
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

            if (Opacity >= 1)
            {
                Opacity = 1;
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
            if (TextToDisplay == ChargerUnplugText)
            {
                PowerStatus p = SystemInformation.PowerStatus;
                int BatteryLevel = (int)(p.BatteryLifePercent * 100);

                TextToDisplay += " " + BatteryLevel + "%";

            }
            else // Show Percentage when plugging Or Show battery full
            {
                if (ShowBatteryPercentage || ShowBatteryFull)
                {
                    PowerStatus p = SystemInformation.PowerStatus;
                    int BatteryLevel = (int)(p.BatteryLifePercent * 100);

                    // Replace text with Battery Full Text (if enabled)
                    if (ShowBatteryFull && BatteryLevel >= BatteryFullLevel)
                    {
                        TextToDisplay = BatteryFullText;
                    }

                    // Add battery percentage to text
                    if (ShowBatteryPercentage && !ShowBatteryFull)
                    {
                        TextToDisplay += " " + BatteryLevel + "%";

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

        private void Overlay_MouseDown(object sender, MouseEventArgs e)
        {
            FadeIn.Stop();
            WaitUntilFadeOut.Stop();
            if (!FadeoutWhenClicking)
            {
                Opacity = 0;
                FadeOut.Stop();
                Visible = false;

            }
            else
            {
                Opacity = 1;
                Visible = true;
                FadeOut.Start();
            }

        }


    }
}
