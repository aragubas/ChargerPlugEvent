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

namespace Installer
{
    public partial class LanguageSelection_LoadingCenterPanel : taiyouUserControl
    {
        public string LanguageFileToLoad;

        public delegate void dLangFileLoaded();
        public event dLangFileLoaded LanguageFileLoaded;

        public LanguageSelection_LoadingCenterPanel()
        {
            InitializeComponent();
        }

        private void LoadLang()
        {
            LoadingTextLabel.Text = TaiyouUtils.Lang.Get("LoadLangFile_LoadingLabel");
        }

        private void LanguageSelection_LoadingCenterPanel_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
            LoadLanguageFile.RunWorkerAsync();

        }

        private void LoadLanguageFile_DoWork(object sender, DoWorkEventArgs e)
        {
            // Load Lang File into TaiyouUtils Lang
            TaiyouUtils.Lang.LoadDictData(LanguageFileToLoad, LoadLanguageFile);
            
            // Call Finish Loading Function
            this.Invoke(new Action(() => FinishLoading()));

            
        }

        private void FinishLoading()
        {
            LanguageFileLoaded.Invoke();
            LoadLang();

        }

        private void LoadLanguageFile_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            LangFileProgressBar.Value = e.ProgressPercentage;
        }

        private void LoadLanguageFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}
