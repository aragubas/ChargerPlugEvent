using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using TaiyouUI;
using TaiyouUtils;

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
            // Set Temp Dir
            TempDirToWorkWith = Path.GetTempPath() + "\\TaiyouChargerPlugEventInstaller\\";

            // Create temporary directory
            Directory.CreateDirectory(TempDirToWorkWith);
            Directory.CreateDirectory(TempDirToWorkWith + "Languages");
            Directory.CreateDirectory(TempDirToWorkWith + "LanguagesReplace");

            // Write UI Theme to file
            File.WriteAllText(TempDirToWorkWith + "UITheme.txt", Properties.Resources.UITheme);

            // Write Avaliable Language Files
            File.WriteAllText(TempDirToWorkWith + "Languages\\English.txt", Properties.Resources.English);
            File.WriteAllText(TempDirToWorkWith + "Languages\\Portugues.txt", Properties.Resources.Portugues);

            // Write Avaliable Language Replace Files
            File.WriteAllText(TempDirToWorkWith + "LanguagesReplace\\English.txt", Properties.Resources.langfile_English);
            File.WriteAllText(TempDirToWorkWith + "LanguagesReplace\\Portuguese.txt", Properties.Resources.langfile_Portuguese);


            // Load UI Theme
            TaiyouUI.ThemeLoader.LoadDictData(TempDirToWorkWith + "UITheme.txt");

            // Set UI Properties
            TaiyouUI.Properties.StrechWindowContentsWhenResizing = true;
            TaiyouUI.Properties.UseForcedDoubleBuffer = true;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create Main Window
            TaiyouUI.Utils.CreateWindow(new InstallerPage1(), "Installer");

            Application.Run();
        }

    }
}
