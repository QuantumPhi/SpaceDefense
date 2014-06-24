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
        public static float SPEED = 16;

        protected Vector3f velocity;
        protected int zTarget;

        public Laser(Vector3f position, GameObject target)
            : base("LASER", 2, 32, "laser.png")
        {
            zTarget = target.ZOrder;
            velocity = new Vector3f(new Vector3f(target.Position.X - position.X, target.Position.Y - position.Y, target.ZOrder).Normalize(), SPEED);
            Rotation = new Vector3f(0, 1, 0).Angle(velocity);
        }

        public override void Update()
        {
            base.Update();

            Position.X -= velocity.X;
            Position.Y -= velocity.Y;
            ZOrder -= (int)velocity.Z;

            Scale.X = 10f / ZOrder;
            Scale.Y = 10f / ZOrder;
        }
    }
}
