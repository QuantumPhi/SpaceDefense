using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceDefense
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

            Game.Initialize(800, 600, 60, new Level());
            Game.SetWindowTitle("SPACE DEFENSE");

            while (!Game.quit)
            {
                Game.Update();
                Application.DoEvents();
            }
        }
    }
}
