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
        protected Vector3f velocity;
        protected int zTarget;

        public Laser(Vector3f position, GameObject target)
            : base("LASER", 2, 32, "laser.png")
        {

        }
    }
}
