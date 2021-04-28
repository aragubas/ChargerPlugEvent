using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using TaiyouUI;
using TaiyouUtils;

namespace Installer
{
    public partial class LanguageSelection : taiyouUserControl
    {
        InstallerPage1 RootInstallPage;
        public LanguageSelection(InstallerPage1 pRootInstallPage)
        {
            InitializeComponent();

            RootInstallPage = pRootInstallPage;
        }

        private void LanguageSelection_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
            LoadAvaliableLanguages();

        }

        private void LoadAvaliableLanguages()
        {
            DirectoryInfo ceira = new DirectoryInfo(Program.TempDirToWorkWith + "\\Languages\\");
            FileInfo[] Ceira = ceira.GetFiles();

            foreach(FileInfo Sinas in Ceira)
            {
                // Ignore non .txt file
                if (Sinas.Extension != ".txt") { continue; }
                AvaliableLanguagesList.Items.Add(Sinas.Name.Replace(".txt", ""));
            }
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            if (AvaliableLanguagesList.SelectedIndex == -1) { return; }
            AcceptButton.Visible = false;
            CenterPanel.Controls.Clear();
            
            LanguageSelection_LoadingCenterPanel ceira = new LanguageSelection_LoadingCenterPanel();

            // Event when loading is complete
            ceira.LanguageFileLoaded += LanguageFileLoaded;
            ceira.LanguageFileToLoad = Program.TempDirToWorkWith + "Languages\\" + AvaliableLanguagesList.SelectedItem.ToString() + ".txt";
            CenterPanel.Controls.Add(ceira);

        }
 
        private void LanguageFileLoaded()
        {
            RootInstallPage.LoadLang();
            RootInstallPage.NextInstallStep();
        }
    }
}
