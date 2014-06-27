using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

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
            InputManager.ShowCursor = false;

            Game.Initialize(1600, 900, 60, new Level());
            Game.SetWindowTitle("SPACE DEFENSE");

            while (!Game.quit)
            {
                Game.Update();
                Application.DoEvents();
            }
        }
    }
}
