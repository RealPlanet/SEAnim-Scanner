using System;
using System.Windows.Forms;

/// 
/// Copyright (C) 2020 by OfficialPLanet (RealPlanet @GitHub) refer to License.txt or ABOUT button at runtime
/// 

namespace SEAnimScanner
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AppWindow());
        }
    }
}
