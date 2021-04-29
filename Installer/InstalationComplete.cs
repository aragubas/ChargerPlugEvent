using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaiyouUI;
using TaiyouUtils;
using System.Diagnostics;
using System.IO;

namespace Installer
{
    public partial class InstalationComplete : taiyouUserControl
    {
        InstallerPage1 RootPage;

        public InstalationComplete(InstallerPage1 pRootPage)
        {
            InitializeComponent();

            RootPage = pRootPage;
        }

        private void InstalationComplete_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
            LoadLang();
        }

        public void LoadLang()
        {
            TitleLabel.Text = TaiyouUtils.Lang.Get("InstalationComplete_Title");
            InstallCompleteLabel.Text = TaiyouUtils.Lang.Get("InstalationComplete_DescriptionText");
            FinishButton.Text = TaiyouUtils.Lang.Get("InstalationComplete_FinishButton");

        }

        private void FinishButton_Click(object sender, EventArgs e)
        {
            // Delete the temporary directory
            Directory.Delete(Program.TempDirToWorkWith, true);
            
            // Start newly installed program
            Process.Start(RootPage.PathToChargerPlugEventExecutable);

            Environment.Exit(0);
        }
    }
}
