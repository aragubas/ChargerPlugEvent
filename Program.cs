/*
   Copyright 2020 Aragubas/Paulo Otávio de Lima

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Media;
using System.Threading;
using System.IO;
using System.Drawing;
using System.Reflection;
using Microsoft.Win32;

namespace ChargerPlugEvent
{
    class Program
    {
        static bool StateChange;
        static bool LastState;
        static bool InSound = true;
        static bool OutSound;
        static int DetectionDelay = 500;
        public static string InstallPath;
        static Overlay OverlayWindow;

        static DateTime BuildDate = new DateTime(2000, 1, 1);

        /// <summary>
        /// Get Version with Build Number
        /// </summary>
        /// <returns></returns>
        public static string GetVersionWithBuild()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version.Major + "." + Assembly.GetExecutingAssembly().GetName().Version.Minor + "." + Assembly.GetExecutingAssembly().GetName().Version.Revision;

            return version.ToString();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Charger Plug Event v" + GetVersionWithBuild());
            OverlayWindow = new Overlay(); 

            // Set Path to current executable path
            InstallPath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

            Console.WriteLine("Current path is: " + InstallPath);

            // Load Properties File
            if (File.Exists(InstallPath + "\\properties.txt"))
            {
                string[] FileLines = File.ReadAllLines(InstallPath + "\\properties.txt");

                foreach (string ceira in FileLines)
                {
                    // Ignore Comment Line
                    if (ceira.StartsWith("#")) { continue; }
                    

                    //Unplug Event Property
                    if (ceira.ToString() == "unplug-event")
                    {
                        OutSound = true;
                    }


                    // Window Size Property
                    if (ceira.ToString().Contains("overlay-size:"))
                    {
                        string[] SinasSplit = ceira.ToString().Split(':')[1].ToString().Split('x');

                        OverlayWindow.Size = new Size(Convert.ToInt32(SinasSplit[0]), Convert.ToInt32(SinasSplit[1]));
                        Console.WriteLine("Overlay size has been set to: (" + OverlayWindow.Size.Width + "," + OverlayWindow.Size.Height + ")");
                    }


                    // Animation Speed Property
                    if (ceira.ToString().Contains("animation-speed:"))
                    {
                        string[] CeiraSplit = ceira.ToString().Split(':');

                        OverlayWindow.AnimationSpeed = float.Parse(CeiraSplit[1]);
                        Console.WriteLine("Animation Speed has been set to: " + OverlayWindow.AnimationSpeed);
                    }


                    // Animation Update Interval Property
                    if (ceira.ToString().Contains("animation-update-interval:"))
                    {
                        string[] CeiraSplit = ceira.ToString().Split(':');

                        OverlayWindow.FadeOut.Interval = Convert.ToInt32(CeiraSplit[1]);
                        OverlayWindow.FadeIn.Interval = Convert.ToInt32(CeiraSplit[1]);

                        Console.WriteLine("Animation Update Interval has been set to: " + OverlayWindow.AnimationSpeed);
                    }


                    // Animation Update Interval Property
                    if (ceira.ToString().Contains("stay-interval:"))
                    {
                        string[] CeiraSplit = ceira.ToString().Split(':');

                        OverlayWindow.WaitUntilFadeOut.Interval = Convert.ToInt32(CeiraSplit[1]);

                        Console.WriteLine("Stay Interval has been set to: " + OverlayWindow.WaitUntilFadeOut.Interval);
                    }


                    // Show battery level property
                    if (ceira.ToString() == "show-battery-level")
                    {
                        OverlayWindow.ShowBatteryPercentage = true;
                    }

                    // Show Battery Full Property
                    if (ceira.ToString() == "show-battery-full")
                    {
                        OverlayWindow.ShowBatteryFull = true;
                    }

                    // Update Interval Property
                    if (ceira.ToString().Contains("update-interval:"))
                    {
                        string[] CeiraSplit = ceira.ToString().Split(':');
                        OverlayWindow.Update.Interval = Convert.ToInt32(CeiraSplit[1]);
                        Console.WriteLine("Detection Delay has been set to: " + OverlayWindow.Update.Interval);
                    }

                    // Font Size Property
                    if (ceira.ToString().Contains("font-size:"))
                    {
                        string[] CeiraSplit = ceira.ToString().Split(':');
                        OverlayWindow.FontSize = Convert.ToInt32(CeiraSplit[1]);
                        Console.WriteLine("Font Size has been set to: " + DetectionDelay);
                    }


                    // Border Width Property
                    if (ceira.ToString().Contains("border-width:"))
                    {
                        string[] CeiraSplit = ceira.ToString().Split(':');
                        OverlayWindow.BorderWidth = Convert.ToInt32(CeiraSplit[1]);
                        Console.WriteLine("Border Width has been set to: " + OverlayWindow.BorderWidth);
                    }


                    // Battery Full Level Property
                    if (ceira.ToString().Contains("battery-full-level:"))
                    {
                        string[] CeiraSplit = ceira.ToString().Split(':');
                        OverlayWindow.BatteryFullLevel = Convert.ToInt32(CeiraSplit[1]);
                        Console.WriteLine("Batery Full Level has been set to: " + OverlayWindow.BatteryFullLevel);

                    }


                    // Background Color Property
                    if (ceira.ToString().Contains("background-color:"))
                    {
                        string[] CeiraSplit = ceira.ToString().Split(':');
                        string CeiraTotal = "";
                        foreach (string Sinecia in CeiraSplit)
                        {
                            CeiraTotal += Sinecia;
                        }
                        CeiraTotal = CeiraTotal.Replace("background-color", "");
                        int R = 255;
                        int G = 255;
                        int B = 255;
                        Console.WriteLine(CeiraSplit.Length);

                        for (int i = 0; i < CeiraSplit.Length + 1; i++)
                        {
                            switch (i)
                            {
                                case 0:
                                    R = Convert.ToInt32(CeiraTotal.Split(',')[i]);
                                    break;

                                case 1:
                                    G = Convert.ToInt32(CeiraTotal.Split(',')[i]);
                                    break;

                                case 2:
                                    B = Convert.ToInt32(CeiraTotal.Split(',')[i]);
                                    break;

                            }
                        }

                        Color Sinas = Color.FromArgb(255, R, G, B);


                        OverlayWindow.BackgroundColor = Sinas;
                        Console.WriteLine("Background color has been set to R:" + R + ",G:" + G + ",B:" + B);
                    }


                    // Border Color Property
                    if (ceira.ToString().Contains("border-color:"))
                    {
                        string[] CeiraSplit = ceira.ToString().Split(':');
                        string CeiraTotal = "";
                        foreach (string Sinecia in CeiraSplit)
                        {
                            CeiraTotal += Sinecia;
                        }
                        CeiraTotal = CeiraTotal.Replace("border-color", "");
                        int R = 255;
                        int G = 255;
                        int B = 255;

                        for (int i = 0; i < CeiraSplit.Length + 1; i++)
                        {
                            switch (i)
                            {
                                case 0:
                                    R = Convert.ToInt32(CeiraTotal.Split(',')[i]);
                                    break;

                                case 1:
                                    G = Convert.ToInt32(CeiraTotal.Split(',')[i]);
                                    break;

                                case 2:
                                    B = Convert.ToInt32(CeiraTotal.Split(',')[i]);
                                    break;

                            }
                        }

                        Color Sinas = Color.FromArgb(255, R, G, B);


                        OverlayWindow.BorderColor = Sinas;
                        Console.WriteLine("Border color has been set to R:" + R + ",G:" + G + ",B:" + B);
                    }


                    // Text Color Property
                    if (ceira.ToString().Contains("text-color:"))
                    {
                        string[] CeiraSplit = ceira.ToString().Split(':');
                        string CeiraTotal = "";
                        foreach (string Sinecia in CeiraSplit)
                        {
                            CeiraTotal += Sinecia;
                        }
                        CeiraTotal = CeiraTotal.Replace("text-color", "");
                        int R = 255;
                        int G = 255;
                        int B = 255;

                        for (int i = 0; i < CeiraSplit.Length + 1; i++)
                        {
                            switch (i)
                            {
                                case 0:
                                    R = Convert.ToInt32(CeiraTotal.Split(',')[i]);
                                    break;
                                
                                case 1:
                                    G = Convert.ToInt32(CeiraTotal.Split(',')[i]);
                                    break;

                                case 2:
                                    B = Convert.ToInt32(CeiraTotal.Split(',')[i]);
                                    break;

                            }
                        }

                        Color Sinas = Color.FromArgb(255, R, G, B);
                        

                        OverlayWindow.TextColor = Sinas;
                        Console.WriteLine("Text color has been set to R:" + R + ",G:" + G + ",B:" + B);
                    }


                    // Text Font Property
                    if (ceira.ToString().Contains("text-font:"))
                    {
                        string[] CeiraSplit = ceira.ToString().Split(':');
                        OverlayWindow.TextFont = CeiraSplit[1];
                        Console.WriteLine("Text Font has been set to: " + OverlayWindow.TextFont);

                    }

                }

                
            }

            if (File.Exists(InstallPath + "\\lang.txt"))
            {
                string[] FileLines = File.ReadAllLines(InstallPath + "\\lang.txt");

                foreach (string ceira in FileLines)
                {
                    if (ceira.StartsWith("#")) { continue; }

                    // Plug Text Property
                    if (ceira.ToString().Contains("PlugText:"))
                    {
                        string[] CeiraSplit = ceira.ToString().Split(':');
                        OverlayWindow.ChargerPlugText = CeiraSplit[1];
                        Console.WriteLine("Plug Text has been set to: " + OverlayWindow.ChargerPlugText);

                    }

                    // Unplug Text Property
                    if (ceira.ToString().Contains("UnplugText:"))
                    {
                        string[] CeiraSplit = ceira.ToString().Split(':');
                        OverlayWindow.ChargerUnplugText = CeiraSplit[1];
                        Console.WriteLine("Unplug Text has been set to: " + OverlayWindow.ChargerUnplugText);

                    }

                    // Battery Full Text Property
                    if (ceira.ToString().Contains("BatteryFullText:"))
                    {
                        string[] CeiraSplit = ceira.ToString().Split(':');
                        OverlayWindow.BatteryFullText = CeiraSplit[1];
                        Console.WriteLine("Battery Full Text has been set to: " + OverlayWindow.BatteryFullText);

                    }


                }

            }
            else
            {
                MessageBox.Show("Cannot find language file.\n\nNão foi possivel encontrar o arquivo de linguagem\n\nNo se puede encontrar el archivo de idioma.\n\n言語ファイルが見つかりません。\n\n找不到语言文件。", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            // Set some properties
            OverlayWindow.OutSound = OutSound;
            OverlayWindow.LoadSounds();
            OverlayWindow.Update.Interval = DetectionDelay;

            Application.Run(OverlayWindow);

            

        }

    }
}
