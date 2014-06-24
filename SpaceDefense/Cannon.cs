using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceDefense
{
    class Cannon : GameObject
    {
        protected int time = 0;

        public Cannon() : base("CANNON", 32, 32, "cannon.png") { }

        public override void Update()
        {
            base.Update();

            
        }
    }
}
