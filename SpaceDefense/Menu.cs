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
            GameObject buttonNormal = new Button(256, 64, "laser.png", Button.StateSwitch.NORMAL_MODE);
            GameObject buttonHard = new Button(256, 64, "laser.png", Button.StateSwitch.HARD_MODE);

            buttonNormal.Position.X = -200;
            buttonHard.Position.X = 200;

            ObjectManager.AddGameObject(buttonNormal);
            ObjectManager.AddGameObject(buttonHard);
        }
    }
}
