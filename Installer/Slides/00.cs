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
    public partial class _00 : taiyouUserControl
    {
        public _00()
        {
            InitializeComponent();
        }

        private void _00_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;

            TitleLabel.Text = TaiyouUtils.Lang.Get("Slide00_Title");

        }
    }
}
