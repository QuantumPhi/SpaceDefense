using Engine;
using SpaceDefense.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceDefense
{
    class Laser : GameObject
    {
        public static float SPEED = 20;
        public GameObject node = new GameObject("LASER", 1, 1, "node.png");
        protected Vector2f velocity;

        public Laser(Vector2f direction)
            : base("LASER", 2, 128, "laser.png")
        {
            velocity = new Vector2f(direction.Normalize() as Vector2f, SPEED);
        }

        public override void Initialize()
        {
            base.Initialize();

            node.Position.X = (float)(Position.X + Height / 2 * Math.Cos((Rotation + 90) * Math.PI / 180));
            node.Position.Y = (float)(Position.Y + Height / 2 * Math.Sin((Rotation + 90) * Math.PI / 180));
            node.CollisionData.SetCollisionData(1);
            node.CollisionData.CollisionEnabled = true;
            ObjectManager.AddGameObject(node);
        }

        public override void Update()
        {
            base.Update();

            IsDead = node.IsDead;

            Position.X -= velocity.X;
            Position.Y -= velocity.Y;
            node.Position.X -= velocity.X;
            node.Position.Y -= velocity.Y;

            if (Position.X > Game.WindowWidth / 2 + 100 || Position.X < -Game.WindowWidth / 2 - 100 ||
                Position.Y > Game.WindowHeight / 2 + 100 || Position.Y < -Game.WindowHeight / 2 - 100)
                IsDead = true;
        }
    }
}
