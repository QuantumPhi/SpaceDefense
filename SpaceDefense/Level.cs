using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceDefense
{
    class Level : State
    {
        public override void Create()
        {
            base.Create();

            GameObject cannon1 = new Cannon();
            cannon1.Position.X = 325;
            GameObject cannon2 = new Cannon();
            cannon2.Position.X = -325;
            GameObject cannon3 = new Cannon();
            cannon3.Position.Y = 225;
            GameObject cannon4 = new Cannon();
            cannon4.Position.Y = -225;
            ObjectManager.AddGameObject(cannon1);
            ObjectManager.AddGameObject(cannon2);
            ObjectManager.AddGameObject(cannon3);
            ObjectManager.AddGameObject(cannon4);
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
