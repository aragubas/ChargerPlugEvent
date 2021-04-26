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

namespace ChargerPlugEvent
{
    class Program
    {
        static bool StateChange;
        static bool LastState;
        static bool InSound = true;
        static bool OutSound;
        static int DetectionDelay = 500;
        static Overlay OverlayWindow;

        static void Main(string[] args)
        {
            OverlayWindow = new Overlay(); 

            if (File.Exists(Environment.CurrentDirectory + "\\properties.txt"))
            {
                string[] FileLines = File.ReadAllLines(Environment.CurrentDirectory + "\\properties.txt");

                foreach (string ceira in FileLines)
                {
                    // Ignore Comment Line
                    if (ceira.StartsWith("#")) { continue; }
                    
                    //Unplug Event Property
                    if (ceira.ToString() == "unplug-event")
                    {
                        OutSound = true;
                    }

                    //Unplug Event Property
                    if (ceira.ToString() == "fadeout-on-click")
                    {
                        OverlayWindow.FadeoutWhenClicking = true;
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

                    // Update Delay Property
                    if (ceira.ToString().Contains("delay:"))
                    {
                        string[] CeiraSplit = ceira.ToString().Split(':');
                        DetectionDelay = Convert.ToInt32(CeiraSplit[1]);
                        Console.WriteLine("Detection Delay has been set to: " + DetectionDelay);
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

                    // Text Font Property
                    if (ceira.ToString().Contains("text-font:"))
                    {
                        string[] CeiraSplit = ceira.ToString().Split(':');
                        OverlayWindow.TextFont = CeiraSplit[1];
                        Console.WriteLine("Text Font has been set to: " + OverlayWindow.TextFont);

                    }


                    // Battery Full Text Property
                    if (ceira.ToString().Contains("BatteryFullText:"))
                    {
                        string[] CeiraSplit = ceira.ToString().Split(':');
                        OverlayWindow.BatteryFullText = CeiraSplit[1];
                        Console.WriteLine("Battery Full Text has been set to: " + OverlayWindow.ChargerUnplugText);

                    }


                }

                
            }

            // Set some properties
            OverlayWindow.OutSound = OutSound;
            OverlayWindow.LoadSounds();
            OverlayWindow.Update.Interval = DetectionDelay;

            Console.WriteLine("Charger plug event started");
            Application.Run(OverlayWindow);

            

        }

    }
}
