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

namespace Installer
{
    public partial class InstallerPage1 : taiyouUserControl
    {
        Size OriginalSize;
        public InstallerPage1()
        {
            InitializeComponent();
            OriginalSize = Size;
        }


        private void InstallerPage1_Load(object sender, EventArgs e)
        {
            RootForm.FormCloseButton.Click += FormCloseButton_Click;
            RootForm.Size = OriginalSize;
            RootForm.ResizeableForm = false;

        }

        void FormCloseButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

    }
}
