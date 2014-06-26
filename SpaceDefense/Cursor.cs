using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceDefense
{
    class Cursor : GameObject
    {
        public int ZTarget { get; private set; }

        public Cursor() : base("CURSOR", 25, 25, "cursor.png") { }

        public override void Initialize()
        {
            base.Initialize();

            ZOrder = 1;
        }

        public override void Update()
        {
            base.Update();
            
            Position.X = InputManager.MousePosition.X - Game.WindowWidth / 2;
            Position.Y = -InputManager.MousePosition.Y + Game.WindowHeight / 2;
        }
    }
}
