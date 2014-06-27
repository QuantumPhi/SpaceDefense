using Engine;
using SpaceDefense.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceDefense
{
    class Player : GameObject
    {
        public Vector2f velocity;
        public XboxController XBController { get; private set; }

        public Player() : base("PLAYER", 70, 64, "ship.png") 
        {
            velocity = new Vector2f();
            XBController = new XboxController(SlimDX.XInput.UserIndex.Two);
        }

        public override void Update()
        {
            base.Update();

            XBController.Update();

            Rotation = XBController.LeftStick.Position.X == 0 && XBController.LeftStick.Position.Y == 0 ? Rotation : (float)(Math.Atan2(XBController.LeftStick.Position.Y, XBController.LeftStick.Position.X) * 180 / Math.PI) - 90;

            if (XBController.LeftStick.Position.X > 0.01f || XBController.LeftStick.Position.X < -0.01f)
            {
                velocity.X = XBController.LeftStick.Position.X * 10;
                Position.X = Math.Abs(Position.X + velocity.X) < Game.WindowWidth / 2 ? Position.X + velocity.X : XBController.LeftStick.Position.X < 0 ? -Game.WindowWidth / 2 : Game.WindowWidth / 2;
            }
            else
            {
                velocity.X = velocity.X < 0 ? velocity.X + 0.25f > 0 ? 0 : velocity.X + 0.25f : velocity.X - 0.25f < 0 ? 0 : velocity.X - 0.25f;
                Position.X = Math.Abs(Position.X + Math.Cos(Rotation * Math.PI / 180 + 90) * velocity.X) < Game.WindowWidth / 2 ? (float)(Position.X + Math.Cos(Rotation * Math.PI / 180 + 90) * velocity.X) : XBController.LeftStick.Position.X < 0 ? -Game.WindowWidth / 2 : Game.WindowWidth / 2;

            }
            if (XBController.LeftStick.Position.Y > 0.01f || XBController.LeftStick.Position.Y < -0.01f)
            {
                velocity.Y = XBController.LeftStick.Position.Y * 10;
                Position.Y = Math.Abs(Position.Y + velocity.Y) < Game.WindowHeight / 2 ? Position.Y + velocity.Y : XBController.LeftStick.Position.Y < 0 ? -Game.WindowHeight / 2 : Game.WindowHeight / 2;
            }
            else
            {
                velocity.Y = velocity.Y < 0 ? velocity.Y + 0.25f > 0 ? 0 : velocity.Y + 0.25f : velocity.Y - 0.25f < 0 ? 0 : velocity.Y - 0.25f;
                Position.Y = Math.Abs(Position.Y + Math.Sin(Rotation * Math.PI / 180 + 90) * velocity.Y) < Game.WindowHeight / 2 ? (float)(Position.Y + Math.Sin(Rotation * Math.PI / 180 + 90) * velocity.Y) : XBController.LeftStick.Position.Y < 0 ? -Game.WindowHeight / 2 : Game.WindowHeight / 2;
            }
            
        }
    }
}
