using Engine;
using SpaceDefense.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceDefense
{
    class Bullet : GameObject
    {
        public static float SPEED = 20;

        protected Vector2f velocity;

        public Bullet(Vector2f direction)
            : base("BULLET", 4, 8, "bullet.png")
        {
            CollisionData.SetCollisionData(2);
            CollisionData.CollisionEnabled = true;

            velocity = new Vector2f(direction.Normalize() as Vector2f, SPEED);
        }

        public override void Update()
        {
            base.Update();

            Position.X -= velocity.X;
            Position.Y -= velocity.Y;

            if (Position.X > Game.WindowWidth / 2 + 100 || Position.X < -Game.WindowWidth / 2 - 100 ||
                Position.Y > Game.WindowHeight / 2 + 100 || Position.Y < -Game.WindowHeight / 2 - 100)
                IsDead = true;
        }
    }
}
