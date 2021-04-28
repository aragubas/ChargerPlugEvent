using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaiyouUtils;
using TaiyouUI;

namespace Installer
{
    public partial class AboutInstall : taiyouUserControl
    {
        InstallerPage1 RootPage;
        public AboutInstall(InstallerPage1 pRootPage)
        {
            InitializeComponent();

            RootPage = pRootPage;
            LoadLang();
        }

        public void LoadLang()
        {
            TitleLabel.Text = TaiyouUtils.Lang.Get("AboutInstall_Title");
            NextButton.Text = TaiyouUtils.Lang.Get("NextButton");

        }

        private void SetSlide(taiyouUserControl SlideControl)
        {
            SlidesPanel.Controls.Clear();
            SlidesPanel.Controls.Add(SlideControl);
        }

        int CurrentSlide = -1;
        public void NextSlide()
        {
            CurrentSlide += 1;

            switch (CurrentSlide)
            {
                case 0:
                    SetSlide(new Slides._00());
                    break;

                case 1:
                    SetSlide(new Slides._01());
                    break;

                default:
                    SlidesPanel.Controls.Clear();
                    RootPage.NextInstallStep();
                    break;

            }
        }

        private void AboutInstall_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;

            NextSlide();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            NextSlide();
        }
    }
}
