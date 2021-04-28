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

namespace Installer.Slides
{
    public partial class _01 : taiyouUserControl
    {
        public _01()
        {
            InitializeComponent();
        }

        private void _01_Load(object sender, EventArgs e)
        {
            LoadLang();
        }

        private void LoadLang()
        {
            TitleLabel.Text = TaiyouUtils.Lang.Get("Slide01_Title");
            DescriptionLabel.Text = TaiyouUtils.Lang.Get("Slide01_Text");

        }
    }
}
