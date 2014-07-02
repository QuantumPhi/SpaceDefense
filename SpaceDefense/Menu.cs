using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceDefense
{
    class Menu : State
    {
        public static bool HardMode { get; set; }

        public override void Create()
        {
            base.Create();

            GameObject cursorA = new Cursor(new XboxController(SlimDX.XInput.UserIndex.One));
            GameObject cursorB = new Cursor(new XboxController(SlimDX.XInput.UserIndex.Two));
            ObjectManager.AddGameObject(cursorA);
            ObjectManager.AddGameObject(cursorB);
            GameObject start = new Button(512, 256, "startbutton.png", Button.StateSwitch.NORMAL_MODE);

            ObjectManager.AddGameObject(start);
        }
    }
}
