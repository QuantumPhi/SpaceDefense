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

            Graphics.DrawCollisionData(true);

            GameObject cursor = new Cursor();
            GameObject player = new Player();
            GameObject cannon1 = new Cannon();
            cannon1.Position.X = 365;
            cannon1.Position.Y = -265;
            GameObject cannon2 = new Cannon();
            cannon2.Position.X = 365;
            cannon2.Position.Y = 265;
            GameObject cannon3 = new Cannon();
            cannon3.Position.X = -365;
            cannon3.Position.Y = 265;
            GameObject cannon4 = new Cannon();
            cannon4.Position.X = -365;
            cannon4.Position.Y = -265;
            ObjectManager.AddGameObject(cursor);
            ObjectManager.AddGameObject(player);
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
