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
        private bool GameOver = false;

        private XboxController cControl;
        private XboxController pControl;

        public Level() : base() { }

        public override void Create()
        {
            base.Create();

            cControl = new XboxController(SlimDX.XInput.UserIndex.One);
            pControl = new XboxController(SlimDX.XInput.UserIndex.Two);

            GameObject cursor = new Cursor(cControl);
            GameObject player = new Player(pControl);
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

            pControl = pControl == null ? new XboxController(SlimDX.XInput.UserIndex.Two) : pControl;

            if (!GameOver && (ObjectManager.GetAllObjectsByName("CANNON").Count == 0 || 
                ObjectManager.GetObjectByName("PLAYER") == null))
            {
                TextManager.AddText("RESTART", "Press START to restart", FontTypes.Arial32);
                TextObject text = TextManager.GetTextObjectByName("RESTART");
                text.Position.X = -Game.WindowWidth / 2;
                text.Position.Y = Game.WindowHeight / 2;
                GameOver = true;
            }

            if (GameOver) 
            {
                pControl.Update();
                if (cControl.IsTriggered(XboxKeys.START) || pControl.IsTriggered(XboxKeys.START))
                    GameStateManager.GoToState(new Level());
            }
        }
    }
}
