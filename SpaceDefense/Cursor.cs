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
        public XboxController XBController { get; protected set; }

        public int ZTarget { get; private set; }

        public Cursor(XboxController x) : base("CURSOR", 25, 25, "cursor.png") 
        {
            XBController = x;

            CollisionData.SetCollisionData(1);
            CollisionData.CollisionEnabled = true;
        }

        public override void Initialize()
        {
            base.Initialize();

            ZOrder = 1;
        }

        public override void Update()
        {
            base.Update();

            XBController.Update();

            if (XBController.LeftStick.Position.X > 0.01f || XBController.LeftStick.Position.X < -0.01f)
            {
                Position.X = Math.Abs(Position.X + XBController.LeftStick.Position.X * 7.5) < Game.WindowWidth / 2 ? Position.X + XBController.LeftStick.Position.X * 7.5f : XBController.LeftStick.Position.X < 0 ? -Game.WindowWidth / 2 : Game.WindowWidth / 2;
            }
            if (XBController.LeftStick.Position.Y > 0.01f || XBController.LeftStick.Position.Y < -0.01f)
            {
                Position.Y = Math.Abs(Position.Y + XBController.LeftStick.Position.Y * 7.5) < Game.WindowHeight / 2 ? Position.Y + XBController.LeftStick.Position.Y * 7.5f : XBController.LeftStick.Position.Y < 0 ? -Game.WindowHeight / 2 : Game.WindowHeight / 2;
            }
        }
    }
}
