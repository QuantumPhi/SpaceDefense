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
        public int Health { get; set; }

        public Vector2f velocity;
        public float rot;
        public XboxController XBController { get; private set; }

        private int timer;
        private int frequency = 6;

        private GameObject healthBar;

        public Player(XboxController x) : base("PLAYER", 70, 64, "ship.png") 
        {
            CollisionData.SetCollisionData(Width / 2);
            CollisionData.CollisionEnabled = true;

            Health = 15;
            velocity = new Vector2f();
            XBController = x;

            healthBar = new HealthBar((uint)Health, this);
            ObjectManager.AddGameObject(healthBar);
        }

        public override void Update()
        {
            base.Update();

            XBController.Update();

            rot = XBController.LeftStick.Position.X == 0 && XBController.LeftStick.Position.Y == 0 ? rot : (float)(Math.Atan2(XBController.LeftStick.Position.Y, XBController.LeftStick.Position.X) * 180 / Math.PI) - 90;
            rot = XBController.RightStick.Position.X == 0 && XBController.RightStick.Position.Y == 0 ? rot : (float)(Math.Atan2(XBController.RightStick.Position.Y, XBController.RightStick.Position.X) * 180 / Math.PI) - 90;

            Rotation += AngleDifference(Rotation, rot) / 5;

            if (XBController.LeftStick.Position.X > 0.01f || XBController.LeftStick.Position.X < -0.01f)
            {
                velocity.X = XBController.LeftStick.Position.X * 10;
                Position.X = Math.Abs(Position.X + velocity.X) < Game.WindowWidth / 2 ? Position.X + velocity.X : XBController.LeftStick.Position.X < 0 ? -Game.WindowWidth / 2 : Game.WindowWidth / 2;
            }
            if (XBController.LeftStick.Position.Y > 0.01f || XBController.LeftStick.Position.Y < -0.01f)
            {
                velocity.Y = XBController.LeftStick.Position.Y * 10;
                Position.Y = Math.Abs(Position.Y + velocity.Y) < Game.WindowHeight / 2 ? Position.Y + velocity.Y : XBController.LeftStick.Position.Y < 0 ? -Game.WindowHeight / 2 : Game.WindowHeight / 2;
            }

            healthBar.Update();

            if (timer == 0 && (XBController.RightStick.Position.X > 0.01f || XBController.RightStick.Position.X < -0.01f || XBController.RightStick.Position.Y > 0.01f || XBController.RightStick.Position.Y < -0.01f))
            {
                Vector2f vel = new Vector2f(-XBController.RightStick.Position.X, -XBController.RightStick.Position.Y);
                GameObject bullet = new Bullet(vel);
                bullet.Position = Position;
                bullet.ZOrder = -1;
                double angle = Math.Atan2(vel.Y, vel.X) + Math.PI / 2;
                bullet.Rotation = (float)(angle * 180 / Math.PI);
                bullet.Position.X += (float)(24 * Math.Cos(angle + Math.PI / 2));
                bullet.Position.Y += (float)(24 * Math.Sin(angle + Math.PI / 2));
                ObjectManager.AddGameObject(bullet);
            }

            timer++;
            timer %= frequency;
        }

        public override void CollisionReaction(CollisionInfo collisionInfo_)
        {
            base.CollisionReaction(collisionInfo_);

            if (collisionInfo_.collidedWithGameObject.Name == "LASER")
            {
                collisionInfo_.collidedWithGameObject.IsDead = true;
                Health--;
            }

            if (Health <= 0)
            {
                healthBar.IsDead = true;
                IsDead = true;
            }
        }

        public float AngleDifference(float angle1, float angle2)
        {
            return -(((((angle1 - angle2) % 360) + 540) % 360) - 180);
        }
    }
}
