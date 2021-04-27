using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using TaiyouUI;

namespace Installer
{
    static class Program
    {
        public static string TempDirToWorkWith;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            TempDirToWorkWith = Path.GetTempPath() + "\\TaiyouChargerPlugEventInstaller\\";

            // Create temporary directory
            Directory.CreateDirectory(TempDirToWorkWith);

            // Write UI Theme to file
            File.WriteAllText(TempDirToWorkWith + "UITheme.txt", Properties.Resources.UITheme);

            // Load UI Theme
            TaiyouUI.ThemeLoader.LoadDictData(TempDirToWorkWith + "UITheme.txt");

            // Set UI Properties
            TaiyouUI.Properties.StrechWindowContentsWhenResizing = true;
            TaiyouUI.Properties.UseForcedDoubleBuffer = true;

            // Create Main Window
            TaiyouUI.Utils.CreateWindow(new InstallerPage1(), "Installer");

            Application.Run();
        }
    }
}
